$(document).ready(function () {

    $('#Desde').datetimepicker(
        {
            format: 'DD/MM/YYYY',
            minDate: moment()

        });
    $('#Hasta').datetimepicker({
        format: 'DD/MM/YYYY',
        useCurrent: false //Important! See issue #1075
    });
    $("#Desde").on("dp.change", function (e) {
        $('#Hasta').data("DateTimePicker").minDate(e.date);
    });
    $("#Hasta").on("dp.change", function (e) {
        $('#Desde').data("DateTimePicker").maxDate(e.date);
    });

    $.validator.addMethod("validCustomer", function (value, element) {
        return value !== "";
    }, "Por favor seleciona una opcion.");
    $.validator.addMethod("requerido", function (value, element) {
        return value !== "";
    }, "Por favor ingrese una fecha valida.");
    $.validator.addMethod("requerido2", function (value, element) {
        return value !== "";
    }, "Por favor ingrese alguna descripción.");

    $("#formCita").validate({
        rules: {
            TipoAtenciones: { validCustomer: true },
            Doctores: { validCustomer: true },
            Pacientes: { validCustomer: true },
            Desde: { requerido: true },
            Hasta: { requerido: true }
        },
        submitHandler: function () {
            $.ajax({
                url: "/citas/ListTurnos",
                method: "post",
                data: {
                    Desde: $("#Desde").val(),
                    Hasta: $("#Hasta").val(),
                    IdDoctor: $("#Doctores").val(),
                }
            })
            .done(function (data) {
                $("#listTurnos").html(data);
                toastr.success("Listado satisfactorio de turnos.");
            })
            .fail(function () {
                toastr.error("Ocurrio un error durante el listado de turnos.");
            });
            return false;
        }
    });

    $("#formRegistroEnfermeria").validate({
        submitHandler: function () {
            alert("im here");
            $.ajax({
                url: "/RegEnfermeria/Save",
                    method: "post",
                    data: {
                        Temperatura : 10
                    }
                })
                .done(function (data) {
                    $("#listTurnos").html(data);
                    toastr.success("Listado satisfactorio de turnos.");
                })
                .fail(function () {
                    toastr.error("Ocurrio un error durante el listado de turnos.");
                });
            return false;
        }
    });
    $("#buscar-paciente").click(function () {
        BuscarPacientes($("#nombre-paciente").val());
    });
    BuscarPacientes();
});

function BuscarPacientes(name) {
    if ($('#ListaPaciente').length > 0) {
        if (name === undefined) {
            name = "";
        }
        $.ajax({
            url: "/RegistroIngreso/GetPacientes",
            method: "GET",
            data: { name: name}
        })
        .done(function (data) {
            $("#ListaPaciente").html(data);
        })
        .fail(function (data) {
            toastr.error(data);
        });
    }
}

function BuscarCama(idSolicitud) {
    $("#IdCitaAnular").val(idSolicitud);

    $.ajax({
        url: "/Solicitud/Nuevo",
            method: "post"
            //data: { idSolicitud: $("#IdCitaAnular").val() }
        })
        .done(function (data) {
            $("#modalAprobar").find('.modal-body').html(data);
            $("#modalAprobar").modal('show');
            var form = $("#formSolicitud");
            form.validate({
                rules: {
                    idCama: { validCustomer: true }
                }
            });
        })
        .fail(function (data) {
            toastr.error(data);
        });
}
function confirmAnularCita(idSolicitud) {
    $("#IdCitaAnular").val(idSolicitud);
    $("#modalAnular").modal('show');
}

function anularCita() {
    $.ajax({
        url: "/Solicitud/DesAprobar",
        method: "post",
        data: { idSolicitud : $("#IdCitaAnular").val() }
    })
    .done(function (data) {
        toastr.success(data);
        location.reload();
    })
    .fail(function (data) {
        toastr.error(data);
    });
}

function AprobarSolicitud() {
    if ($("#formSolicitud").valid()) {
        $.ajax({
                url: "/Solicitud/Aprobar",
                method: "post",
                data: {
                    idSolicitud: $("#IdCitaAnular").val(),
                    idCama: $("#idCama").val()
                }
            })
            .done(function (data) {
                toastr.success(data);
                location.reload();
            })
            .fail(function (data) {
                toastr.error(data);
            });
    }
}
function reservarCita(idTurno) {
    toastr.success("Seleccion " + idTurno);
    // preventDefault();

    $.ajax({
        url: "/citas/reservarTurno",
        method: "post",
        data: {
            IdTipoAtencion: $("#TipoAtenciones").val(),
            IdDoctor: $("#Doctores").val(),
            IdPaciente: $("#Pacientes").val(),
            IdTurno: idTurno
        }
    })
        .done(function (data) {
            toastr.success(data);
            $("#modalReservaMensaje").text("Se realizo tu solicitud sin problemas.");
            $("#modalReserva").modal('show');
        })
        .fail(function (data) {
            toastr.error(data);
            $("#modalReservaMensaje").text("Hubo un problema durante el proceso.");
            $("#modalReserva").modal('show');
        });
}

function closeModal(id) {
    $(id).modal('hide');
}

function NuevoDetalleRegistro(idRegistroIngreso) {
    $.ajax({
        url: "/RegEnfermeria/Nuevo",
        method: "POST",
        data: {
            idRegistroIngreso: idRegistroIngreso
        }
    })
    .done(function (data) {
        $("#modalNuevoRegistroEnf").find('.modal-body').html(data);
        $("#modalNuevoRegistroEnf").modal('show');
            ValidateFormRegEnfermeria();
        })
    .fail(function (data) {
        toastr.error(data);
    });
}

function EnviarFormularioRegEnf() {
    $("#formRegistroEnfermeria").submit();
}

function ValidateFormRegEnfermeria() {
    $("#formRegistroEnfermeria").validate({
        rules : {
            HrmTemperatura: {
                required: true,
                range: [20, 45]
            },
            HrmRitmoCard: {
                required: true,
                range: [1, 20]
            },
            HrmPsPd: {
                required: true,
                range: [1, 20]
            },
            HrmPcmPap: {
                required: true,
                range: [1, 20]
            },
            HrmPam: {
                required: true,
                range: [1, 20]
            },
            HrmGcIc: {
                required: true,
                range: [1, 20]
            },
            RespModalidad: {
                required: true,
                range: [1, 4]
            },
            RespVc: {
                required: true,
                range: [1, 20]
            },
            RespFr: {
                required: true,
                range: [1, 20]
            },
            RespPeeps: {
                required: true,
                range: [1, 20]
            },
            RespFio2: {
                required: true,
                range: [1, 20]
            },
            RespSatO2: {
                required: true,
                range: [1, 20]
            },
            NeuroPupila: {
                required: true,
                range: [1, 4]
            },
            NeuroEstadoConc: {
                required: true,
                range: [1, 4]
            },
            NeuroGlosgow: {
                required: true,
                range: [1, 20]
            },
            NeuroRamsay: {
                required: true,
                range: [1, 20]
            },
            NeuroMotSd: {
                required: true,
                range: [1, 20]
            },
            NeuroMotSi: {
                required: true,
                range: [1, 20]
            },
            HidriIngresos: {
                required: true,
                range: [1, 20]
            },
            HidriEgresos: {
                required: true,
                range: [1, 20]
            }
        },
        submitHandler: function (form) {
           
            $.ajax({
                url: "/RegEnfermeria/Save",
                method: "post",
                data: objectifyForm($(form).serializeArray())
                })
                .done(function (data) {
                    $("#modalNuevoRegistroEnf").modal('hide');
                    toastr.success("Se guardo el registro.");
                })
                .fail(function () {
                    toastr.error("Ocurrio un error durante el Proceso.");
                });
            return false;
        }
    });
}

function objectifyForm(formArray) {//serialize data function

    var returnArray = {};
    for (var i = 0; i < formArray.length; i++) {
        returnArray[formArray[i]['name']] = formArray[i]['value'];
    }
    return returnArray;
}

function VerDetalleRegistro(idRegistroIngreso) {
    $("#modalDetalleRegistroEnf").modal("show");
    for (var i = 0; i < 4; i++) {
        $("#content-chart" + i).remove();
    }
    $.ajax({
        url: "/RegEnfermeria/GetValuesFactor",
        method: "post",
        data: {
            idRegistroIngreso: idRegistroIngreso
        }
    })
        .done(function (data) {

            $.each(data, function (key, value) {
                $("#content-chart").clone().prop('id', 'content-chart' + key).addClass("margin-bottom").insertBefore("#content-chart");
                Highcharts.chart('content-chart' + key,
                    {
                        chart: {
                            marginBottom: 55
                        },
                        title: {
                            text: "Monitreo: " + value.Nombre
                        },
                        xAxis: {
                            categories: GetArrayCategories(value.RegistroEnfermerias)
                        },
                        yAxis: [{ // left y axis
                            title: {
                                text: null
                            },
                            labels: {
                                align: 'left',
                                x: 3,
                                y: 16,
                                format: '{value:.,0f}'
                            },
                            showFirstLabel: false
                        }, { // right y axis
                            linkedTo: 0,
                            gridLineWidth: 0,
                            opposite: true,
                            title: {
                                text: null
                            },
                            labels: {
                                align: 'right',
                                x: -3,
                                y: 16,
                                format: '{value:.,0f}'
                            },
                            showFirstLabel: false
                        }],
                        legend: {
                            align: 'center',
                            verticalAlign: 'bottom',
                            y: 20,
                            floating: true,
                            borderWidth: 0
                        },
                        tooltip: {
                            shared: true,
                            crosshairs: true
                        },
                        plotOptions: {
                            series: {
                                cursor: 'pointer',
                                point: {
                                    events: {
                                        click: function (e) {
                                            var idRegistro = this.idRegsitro;
                                            $.ajax({
                                                    url: "/RegEnfermeria/GetRegistro",
                                                    method: "GET",
                                                    data: {
                                                        idRegistro: idRegistro
                                                    }
                                                })
                                                .done(function (data) {
                                                    $("#modalDetalleRegistroEnf").modal("hide");
                                                    $("#modalNuevoRegistroEnf").find('.modal-body').html(data);
                                                    $("#modalNuevoRegistroEnf").modal('show');
                                                    ValidateFormRegEnfermeria();
                                                })
                                                .fail(function (data) {
                                                    toastr.error(data);
                                                });
                                            //hs.htmlExpand(null, {
                                            //    pageOrigin: {
                                            //        x: e.pageX || e.clientX,
                                            //        y: e.pageY || e.clientY
                                            //    },
                                            //    headingText: this.series.name,
                                            //    maincontentText: Highcharts.dateFormat('%A, %b %e, %Y', this.x) + ':<br/> ' +
                                            //        this.y + ' visits',
                                            //    width: 200
                                            //});
                                        }
                                    }
                                },
                                marker: {
                                    lineWidth: 1
                                }
                            }
                        },
                        //plotOptions: {
                        //    series: {
                        //        pointStart: 1
                        //    }
                        //},

                        series: GetArrayValues(value.FactorRiesgosHijos)
                    });
                
            });
            
        })
        .fail(function () {
            toastr.error("Ocurrio un error durante el proceso.");
        });

}
function GetArrayValues(series) {
    var jsonObj = [];
    $.each(series, function (key, value) {

        var item = {};
        item["name"] = value.Codigo;
        item["data"] = [];

        $.each(value.Values, function(key2, value2) {
            var subItem = {};
            subItem["y"] = value2;
            subItem["idRegsitro"] = value.IdRegistros[key2];
            item["data"].push(subItem);
        });

        jsonObj.push(item);
    });
    return jsonObj;

}

function GetArrayCategories(registros) {
    var jsonObj = [];
    $.each(registros, function (key, value) {

        jsonObj.push(value.FechaRegistroString);
    });
    return jsonObj;

}

function NuevoDiagnostico(idRegistroIngreso) {
    $.ajax({
        url: "/DiagnosticoGravedad/Nuevo",
        method: "POST",
        data: {
            idRegistroIngreso: idRegistroIngreso
        }
    })
    .done(function (data) {
        $("#content-form-diag").html(data);
        $("#modalNuevoDiagnostico").modal('show');
        CreateChart(idRegistroIngreso, $("#cantidadRegistros").val());
        ValidateFormDiagnostico();
    })
    .fail(function (data) {
        toastr.error(data);
    });
}
function ActualizarChart(event) {
    event.preventDefault();
    CreateChart($("#IdIngresoSalidaPaciente").val(), $("#cantidadRegistros").val());
    return false;
}
function CreateChart(idRegistroIngreso, cantidad) {
    if (cantidad === undefined || cantidad === "") cantidad = 0;
    for (var i = 0; i < 4; i++) {
        $("#content-chart" + i).remove();
    }
    $.ajax({
        url: "/DiagnosticoGravedad/GetValuesCriticidad2",
        method: "post",
        data: {
            idRegistroIngreso : idRegistroIngreso,
            cantidad : cantidad
        }
    })
    .done(function (data) {

        $.each(data, function (key, value) {
            $("#content-chart").clone().prop('id', 'content-chart' + key).addClass("margin-bottom").insertBefore("#content-chart");
            Highcharts.chart('content-chart' + key, {
                chart: {
                    type: 'column'
                },
                title: {
                    text: "Monitreo: " + value.Nombre
                },
                xAxis: {
                    categories: GetArrayCategories(value.RegistroEnfermerias),
                    crosshair: true
                },
                yAxis: {
                    min: 0,
                    title: {
                        text: 'Nivel de Criticidad'
                    }
                },
                tooltip: {
                    headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                    pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                        '<td style="padding:0"><b>Criticidad {point.y}</b></td></tr>',
                    footerFormat: '</table>',
                    shared: true,
                    useHTML: true
                },
                plotOptions: {
                    column: {
                        pointPadding: 0.2,
                        borderWidth: 0
                    }
                },
                series: GetArrayValues(value.FactorRiesgosHijos)
            });
            //Highcharts.chart('content-chart' + key, {
            //    chart: {
            //        type: 'bar'
            //    },
            //    title: {
            //        text: "Monitreo: " + value.Nombre
            //    },
            //    xAxis: {
            //        categories: GetArrayCategories(value.RegistroEnfermerias),
            //        title: {
            //            text: null
            //        }
            //    },
            //    yAxis: {
            //        min: 0,
            //        title: {
            //            text: 'Resgistro',
            //            align: 'high'
            //        },
            //        labels: {
            //            overflow: 'justify'
            //        }
            //    },
            //    tooltip: {
            //        valueSuffix: ' millions'
            //    },
            //    plotOptions: {
            //        bar: {
            //            dataLabels: {
            //                enabled: true
            //            }
            //        }
            //    },
            //    legend: {
            //        layout: 'vertical',
            //        align: 'right',
            //        verticalAlign: 'top',
            //        x: -40,
            //        y: 80,
            //        floating: true,
            //        borderWidth: 1,
            //        backgroundColor: ((Highcharts.theme && Highcharts.theme.legendBackgroundColor) || '#FFFFFF'),
            //        shadow: true
            //    },
            //    credits: {
            //        enabled: false
            //    },
            //    series: GetArrayValues(value.FactorRiesgosHijos)
            //});
            //Highcharts.chart('content-chart' + key,
            //    {
            //        chart: {
            //            type: 'column',

            //        },
            //        title: {
            //            text: "Monitreo: " + value.Nombre
            //        },
            //        xAxis: {
            //            categories: GetArrayCategoriesDiag(value.FactorRiesgosHijos)
            //        },
            //        yAxis: {
            //            min: 0,
            //            title: {
            //                text: 'Porcentaje de sucesos'
            //            }
            //        },
            //        legend: {
            //            reversed: true
            //        },
            //        plotOptions: {
            //            series: {
            //                stacking: 'percent'
            //            }
            //        },
            //        series: GetArrayValuesDiag(value.NivelCriticidades)
            //    });

        });

    })
    .fail(function () {
        toastr.error("Ocurrio un error durante el proceso.");
    });
}
function GetArrayValuesDiag(criticiades) {
    var jsonObj = [];
    $.each(criticiades, function (key, value) {
        var item = {};
        item["name"] = value.Nombre;
        item["data"] = value.Values;
        jsonObj.push(item);
    });
    return jsonObj;
}
function GetArrayCategoriesDiag(factores) {
    var jsonObj = [];
    $.each(factores, function (key, value) {
        jsonObj.push(value.Codigo);
    });
    return jsonObj;
}
function VerDiagnostico(idRegistroIngreso) {
    $.ajax({
            url: "/DiagnosticoGravedad/Detalle",
            method: "POST",
            data: {
                idRegistroIngreso: idRegistroIngreso
            }
        })
        .done(function (data) {
            $("#modalVerDiagnostico").find(".modal-body").html(data);
            $("#modalVerDiagnostico").modal('show');
        })
        .fail(function (data) {
            toastr.error(data);
        });
}

function EnviarFormDiagnstico() {
    $("#formDiagnosticoGravedad").submit();
}

function ValidateFormDiagnostico() {
    $("#formDiagnosticoGravedad").validate({
        rules : {
            IdNivelCriticidad: { validCustomer: true },
            Observacion: { requerido2: true },
        },
        submitHandler: function (form) {
            $.ajax({
                url: "/DiagnosticoGravedad/Save",
                    method: "post",
                    data: objectifyForm($(form).serializeArray())
                })
                .done(function (data) {
                    $("#modalNuevoDiagnostico").modal('hide');
                    BuscarPacientes();
                    toastr.success("Se guardo el registro.");
                })
                .fail(function () {
                    toastr.error("Ocurrio un error durante el Proceso.");
                });
            return false;
        }
    });
}