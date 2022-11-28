/*
 *
 * Project Name: Manten - Style 11
 * URL: http://templatesuper.com
 * Version: 1.1
 *
 * Author: Adnan
 *
 */

// HEADER SLIDER
$(window).load(function() {
    $('.flexslider').flexslider({
        animation: "slide",
        controlNav: true,
        directionNav: true
    });
});

$(document).ready(function() {
    // SCROLLSPY
    $('body').scrollspy({
        target: '#navbar'
    })

    // SMOOTHSCROLL
    $('a[href^="#"]').on('click', function(e) {
        e.preventDefault();

        var target = this.hash;
        var $target = $(target);

        $('html, body').stop().animate({
            'scrollTop': $target.offset().top
        }, 900, 'swing');

        $('.navbar-collapse.collapse').removeClass("show");
    });
});

// SAVE TO CSV
/*
$(function() {
    $(".submit").click(function() {
        var name = $("#name").val();
        var dataString = 'name=' + name;

        if (name == '') {
            $('.alert-danger').fadeIn().show();
        } else {
            $.ajax({
                type: "POST",
                url: "rsvp.php",
                data: dataString,
                success: function() {
                    $('.alert-danger').fadeIn().hide();
                    $('.alert-success').fadeIn().fadeOut(3000);
                }
            });
        }
        return false;
    });
});
*/

// SCROLLREVEAL
window.sr = ScrollReveal();
sr.reveal('#home .caption', {
    duration: 1500,
    reset: true
}, 50);
sr.reveal('#story', {
    duration: 1500,
    reset: true
}, 50);
sr.reveal('#wedding .col-md-12, #wedding .col-md-4', {
    duration: 1500,
    reset: true
}, 50);
sr.reveal('#accomm .container', {
    duration: 1500,
    reset: true
}, 50);
sr.reveal('#registry .container', {
    duration: 2000,
    reset: true
}, 200);
sr.reveal('#info .container', {
    duration: 2000,
    reset: true
}, 200);
sr.reveal('#rsvp .container', {
    duration: 1500,
    reset: true
}, 50);

dotvvm.events.postbackViewModelUpdated.subscribe(function () {
    if (dotvvm.viewModels.root.viewModel.AllOk() == false) {
        $('.alert-danger').fadeIn().show();
    } else if (dotvvm.viewModels.root.viewModel.AllOk() == true) {
        $('.alert-danger').fadeIn().hide();
        $('.alert-success').fadeIn().fadeOut(3000);
    }
});