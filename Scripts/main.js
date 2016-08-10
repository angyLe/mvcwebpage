


$(document).ready(function () {


    console.log ('mixitup '+ $("#Container1").val() );

    //if ($("#Container1") == "undefined ") {
        $(function () {
            $('#Container1').mixItUp();
        });
    //};

    /*for the validation custom attributes
    //url smarly.net/asp-net-mvc-4-in-action/working-with-asp-net-mvc/validation/client-side-validation
    //url  andrey.moveax.ru/post/mvc3-in-depth-part12-custom-clientside-validation
   

    jQuery.validator.addMethod("equal", function (value, element, param) {
        if ($(element).attr("type") == "checkbox") {
            value = String($(element).attr("checked"));
            param = param.toLowerCase();
        }

        return (value == param);
    });

    jQuery.validator.unobtrusive.adapters.addSingleVal("equal", "valuetocompare");
    */


    

   
//}); 


});

//уже загружены картинки
$(window).load(function () {
    $(".loader_inner").fadeOut();
    $(".loader").delay(400).fadeOut("slow");

});
