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
    $.ajax({
            url: "/Solicitud/Aprobar",
            method: "post",
            data: {
                idSolicitud: $("#IdCitaAnular").val(),
                idCama: $("#IdCitaAnular").val()
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
        item["data"] = value.Values;
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
        CreateChart(idRegistroIngreso);
            ValidateFormDiagnostico();
        })
    .fail(function (data) {
        toastr.error(data);
    });
}

function CreateChart(idRegistroIngreso) {
    for (var i = 0; i < 4; i++) {
        $("#content-chart" + i).remove();
    }
    $.ajax({
        url: "/DiagnosticoGravedad/GetValuesCriticidad",
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
                        type: 'column',

                    },
                    title: {
                        text: "Monitreo: " + value.Nombre
                    },
                    xAxis: {
                        categories: GetArrayCategoriesDiag(value.FactorRiesgosHijos)
                    },
                    yAxis: {
                        min: 0,
                        title: {
                            text: 'Porcentaje de sucesos'
                        }
                    },
                    legend: {
                        reversed: true
                    },
                    plotOptions: {
                        series: {
                            stacking: 'percent'
                        }
                    },
                    series: GetArrayValuesDiag(value.NivelCriticidades)
                });

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