document.addEventListener("DOMContentLoaded", function () {
    $('#form-change-password').validate({
        rules: {
            oldPassword: {
                required: true,
                minlength: 10,
                maxlength: 100
            },
            newPassword: {
                required: true,
                minlength: 10,
                maxlength: 100,
                pattern: /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#])[0-9a-zA-Z!@#]{10,}$/
            }
        },
        messages: {
            oldPassword: {
                required: "Please enter your old password.",
                minlength: "Your old password must be at least 10 characters long.",
                maxlength: "Your old password must be no more than 100 characters long."
            },
            newPassword: {
                required: "Please enter a new password.",
                minlength: "Your new password must be at least 10 characters long.",
                maxlength: "Your new password must be no more than 100 characters long.",
                pattern: "Your new password must contain at least one digit, one lowercase letter, one uppercase letter, and one of the following special characters: !@#."
            }
        },
        submitHandler: function (form) {
            form.submit();
        }
    });
});