$(document).ready(function () {
    $(".slider").on("click", function () {
        if ($(".slider:checked")) {
            document.cookie = "Dkmode=true;";
        }
        else if ($(!".slide:checked")) {
            console.log("notclickied");
            $.cookie = "Dkmode=; expires=Thu, 01 Jan 1970 00:00:00 UTC;"
        }
    });
});


