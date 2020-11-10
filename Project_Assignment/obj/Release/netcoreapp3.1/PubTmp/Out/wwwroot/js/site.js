// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// validation for email and phone fields
function runValidation() {
    // get phone and email elements
    let email = document.getElementById("form-email");
    let phone = document.getElementById("form-phone");

    // return if phone and/or email field is empty
    if (phone.value == "" || email.value == "") {
        return;
    }

    // define phone and email regex
    let regPhone = /^\d{10}$/;
    let regEmail = /^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$/;

    let error = false;

    // test phone value
    if (!regPhone.test(phone.value)) {
        alert("Please Enter a Valid 10-digit Phone Number");
        error = true;
    }

    // test email value
    if (!regEmail.test(email.value)) {
        alert("Please Enter a Valid Email Address");
        error = true;
    }

    if (error) {
        return false;
    }

    return true;
}