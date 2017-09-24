var loginModule = (function() {
    var elements = {
        idFormLogin: "#form-login",
        idMensajeError: "#mensaje-error",
        },
        urlHome = "/Home";
    function init() {
        
    }
    function setUpForm() {
        $(elements.idFormLogin).validate({
            rules: {
                Password: "required",
                UserName: {
                    required: true,
                    email: true
                }
            },
            submitHandler: function (form) {
                $.ajax({
                    url: "/Login/LogIn",
                    method: "post",
                    data: objectifyForm($(form).serializeArray())
                })
                    .done(function (data) {
                        if (data.estado === "ok") {
                             window.location = window.location.origin + urlHome;
                        } else {
                            $(elements.idMensajeError).fadeIn();
                        }
                       
                    })
                .fail(function () {
                    $(elements.idMensajeError).fadeOut();
                });
                return false;
            }
        });
    }
    return {
        init: init,
        setUpForm: setUpForm
    };
})();

$(document).ready(function () {
    loginModule.init();
    loginModule.setUpForm();
});