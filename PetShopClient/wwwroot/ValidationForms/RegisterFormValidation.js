document.addEventListener("DOMContentLoaded", function () {
    $.validator.setDefaults({
        errorClass: 'text-danger',
    });

    // Initialize form validation
    var validator = $("form").validate({
        rules: {
            username: {
                required: true,
            },
            password: {
                required: true,
                minlength: 6, // Password must be at least 6 characters long
            },
            confirmPassword: {
                required: true,
                equalTo: "#password", // Confirm password must match password
            },
        },
        messages: {
            username: {
                required: "Please enter a username",
            },
            password: {
                required: "Please enter a password",
                minlength: "Password must be at least 6 characters long",
            },
            confirmPassword: {
                required: "Please confirm your password",
                equalTo: "Passwords do not match",
            },
        },
    });

    // Handle form submission
    $("#submitBtn").on("click", function (e) {
        e.preventDefault();

        if (validator.form()) { // Check if form is valid
            $("form").trigger("submit");
        }
    });
})