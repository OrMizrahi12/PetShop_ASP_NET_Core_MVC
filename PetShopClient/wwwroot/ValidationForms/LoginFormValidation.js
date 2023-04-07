
document.addEventListener('DOMContentLoaded', function () {

    $.validator.setDefaults({
        errorClass: 'text-danger',
    });

    var validator = $("form").validate({
        rules: {
            username: {
                required: true,
            },
            password: {
                required: true,
            },
        },
        messages: {
            username: {
                required: "Please enter a username",
            },
            password: {
                required: "Please enter a password",
            },
        },
    });
    $("#submitBtn").on("click", function (e) {
        e.preventDefault();

        if (validator.form()) { // Check if form is valid
            $("form").trigger("submit");
        } 
    });
})



