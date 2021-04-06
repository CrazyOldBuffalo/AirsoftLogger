function searchcheck() {
    var SearchItem = $("#SearchString").val();
    if (SearchItem == '') {
        alert("Please Enter A Search Term");
        return false;
    }
}