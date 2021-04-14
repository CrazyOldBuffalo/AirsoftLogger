$(document).ready(function () {
    var TopofPage = $('#Top');

    window.onscroll = function () { scrollFunction() };

    function scrollFunction() {
        if (document.body.scrollTop > 40 || document.documentElement.scrollTop > 40) {
            TopofPage.show();
        } else {
            TopofPage.hide();
        }
    }


});

function toppage() {
    $(document.body).scrollTop(0);
    $(document.documentElement).scrollTop(0);
}