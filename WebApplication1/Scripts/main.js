
$(document).ready(function () {
    console.log('mixitup ' + $("#Container1").val());

    $(function () {
        $('#Container1').mixItUp();
    });

});

$(window).load(function () {
    $(".loader_inner").fadeOut();
    $(".loader").delay(400).fadeOut("slow");
});
