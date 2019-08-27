// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

$("#order_form").validate({
    rules: {
        FirstName: "required",
        LastName: "required",
        CustomerEmail: {
            required: true,
            email: true
        },
        Address1: {
            required: true,
            minlength: 20,
            maxlength: 250
        },
        PhoneNumber: "required",
        ZipCode: "required"
    },

    messages: {
        FirstName: "Please enter your first name",
        LastName: "Please enter your last name",
        CustomerEmail: {
            required: "Please enter email address",
            email: "Please enter valid email address"
        },
        Address1: {
            required: "Please enter address",
            minlength: "Your address must be at least 20 characters long",
            maxlength: "Your address must be below 250 characters"
        },
        PhoneNumber: "Enter phone number",
        ZipCode: "Please enter zip code"
    },

    submitHandler: function (form) {
        form.submit();
    }
});

$("#shopping-cart-preview-header").click(function () {
    $("#shopping-cart-preview-body").slideToggle(); // display: block or none
})

$(function() {
    // Login Register Form
    $('#login-register-forms #forgot_pswd').click(toggleResetPswd);
    $('#login-register-forms #cancel_reset').click(toggleResetPswd);
    $('#login-register-forms #btn-signup').click(toggleSignUp);
    $('#login-register-forms #cancel_signup').click(toggleSignUp);
});

function toggleResetPswd(e) {
    e.preventDefault();
    $('#login-register-forms .form-sign-in').toggle() // display:block or none
    $('#login-register-forms .form-reset').toggle() // display:block or none
}

function toggleSignUp(e) {
    e.preventDefault();
    $('#login-register-forms .form-sign-in').toggle(); // display:block or none
    $('#login-register-forms .form-sign-up').toggle(); // display:block or none
}

//Home/Index
$('#top-selling-slider').slick({
    arrows: true,
    centerMode: true,
    centerPadding: '40px',
    slidesToShow: 4,
    autoplay: true,
    autoplaySpeed: 2000,
    prevArrow: $('#topselling-prev'),
    nextArrow: $('#topselling-next'),
    responsive: [
        {
            breakpoint: 992,
            settings: {
                arrows: false,
                centerMode: true,
                centerPadding: '35px',
                slidesToShow: 2
            }
        },
        {
            breakpoint: 768,
            settings: {
                arrows: false,
                centerMode: true,
                centerPadding: '30px',
                slidesToShow: 1
            }
        }
    ]
});

$('#discount-items').slick({
    arrows: true,
    centerMode: true,
    centerPadding: '40px',
    slidesToShow: 4,
    autoplay: true,
    autoplaySpeed: 2000,
    prevArrow: $('#discount-prev'),
    nextArrow: $('#discount-next'),
    responsive: [
        {
            breakpoint: 992,
            settings: {
                arrows: false,
                centerMode: true,
                centerPadding: '35px',
                slidesToShow: 2
            }
        },
        {
            breakpoint: 768,
            settings: {
                arrows: false,
                centerMode: true,
                centerPadding: '30px',
                slidesToShow: 1
            }
        }
    ]
});

$('#new-items').slick({
    arrows: true,
    centerMode: true,
    centerPadding: '40px',
    slidesToShow: 4,
    autoplay: true,
    autoplaySpeed: 2000,
    prevArrow: $('#new-items-prev'),
    nextArrow: $('#new-items-next'),
    responsive: [
        {
            breakpoint: 992,
            settings: {
                arrows: false,
                centerMode: true,
                centerPadding: '35px',
                slidesToShow: 2
            }
        },
        {
            breakpoint: 768,
            settings: {
                arrows: false,
                centerMode: true,
                centerPadding: '30px',
                slidesToShow: 1
            }
        }
    ]
});