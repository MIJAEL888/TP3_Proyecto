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
});

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
                    $("#listTurnos").html(data);
                    toastr.success("Listado satisfactorio de turnos.");
                })
                .fail(function () {
                    toastr.error("Ocurrio un error durante el listado de turnos.");
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