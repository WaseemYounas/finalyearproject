$(document).ready(function(){
    
    (function($) {
        "use strict";

    
    jQuery.validator.addMethod('answercheck', function (value, element) {
        return this.optional(element) || /^\bcat\b$/.test(value)
    }, "type the correct answer -_-");

    // validate contactForm form
        $(function () {
            $('#contactForm').validate({
                rules: {
                    name: {
                        required: true,
                        minlength: 2
                    },
                    subject: {
                        required: true,
                        minlength: 4
                    },
                    number: {
                        required: true,
                        minlength: 5
                    },
                    email: {
                        required: true,
                        email: true
                    },
                    message: {
                        required: true,
                        minlength: 20
                    }
                },
                messages: {
                    name: {
                        required: "come on, you have a name, don't you?",
                        minlength: "your name must consist of at least 2 characters"
                    },
                    subject: {
                        required: "come on, you have a subject, don't you?",
                        minlength: "your subject must consist of at least 4 characters"
                    },
                    number: {
                        required: "come on, you have a number, don't you?",
                        minlength: "your Number must consist of at least 5 characters"
                    },
                    email: {
                        required: "no email, no message"
                    },
                    message: {
                        required: "um...yea, you have to write something to send this form.",
                        minlength: "thats all? really?"
                    }
                },
                submitHandler: function (form) {
                    $(form).ajaxSubmit({
                        type: "POST",
                        data: $(form).serialize(),
                        url: "contact_process.php",
                        success: function () {
                            $('#contactForm :input').attr('disabled', 'disabled');
                            $('#contactForm').fadeTo("slow", 1, function () {
                                $(this).find(':input').attr('disabled', 'disabled');
                                $(this).find('label').css('cursor', 'default');
                                $('#success').fadeIn()
                                $('.modal').modal('hide');
                                $('#success').modal('show');
                            })
                        },
                        error: function () {
                            $('#contactForm').fadeTo("slow", 1, function () {
                                $('#error').fadeIn()
                                $('.modal').modal('hide');
                                $('#error').modal('show');
                            })
                        }
                    })
                }
            })
        })

    // validate Login form
        $(function () {
            debugger
            $('#login_form').validate({
                rules: {
                    Name: {
                        required: true
                    },
                    Email: {
                        required: true,
                        email: true
                    },
                    Phone: {
                        required: true,
                        minlength: 11
                    },
                    Address: {
                        required: true,
                        minlength: 6
                    },
                    Password: {
                        required: true,
                        minlength: 6
                    },
                    CPassword: {
                        required: true,
                        minlength: 6,
                        equal: "#password"
                    }
                },
                messages: {
                    Name: {
                        required: "come on, you have a name, don't you?"
                    },
                    Email: {
                        required: "come on, you have an email, don't you?",
                        email: "please enter valid email."
                    },
                    Phone: {
                        required: "come on, you have a number, don't you?",
                        minlength: "your Number must consist of at least 11 characters"
                    },
                    Address: {
                        required: "come on, you have a number, don't you?",
                        minlength:"please enter more than 6 charaters long address"
                    },
                    Password: {
                        required: "um...yea, you have to write password to send this form.",
                        minlength: "thats all? really? Please enter atleast 6 characters."
                    },
                    CPassword: {
                        required: "um...yea, you have to write confirm password to send this form.",
                        minlength: "thats all? really? Please enter atleast 6 characters.",
                        equal:"password and confirm password must be same."
                    }
                },
                submitHandler: function (form) {
                    $(form).submit();
                }
            })
        })
        
 })(jQuery)
})