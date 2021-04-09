function SiteCheck() {
    var sitecheck;
    var sitecode = $(".siteCode").val();
    var city = $(".City").val();
    var tel = $(".Tel").val();
    var postcode = $(".PostCode").val();
    var sitename = $(".siteName").val();

    if (sitecode == "" || sitecode.length < 2) {
        $("#sitecodewarn").html("A Site MUST have a Valid Sitecode");
        sitecheck = false;
    }
    if (city == "" || city.length < 2 ) {
        $("#sitecitywarn").html("A Site MUST have a Valid City");
        sitecheck = false;
    }
    if (tel == "" || tel.length < 4) {
        $("#sitetelwarn").html("A Site MUST have a Valid Contact Number");
        sitecheck = false;
    }
    if (postcode == "" || postcode.length < 4) {
        $("#sitepostcodewarn").html("A Site MUST have a Valid Postcode");
        sitecheck = false;
    }
    if (sitename == "" || sitename.length < 4) {
        $("#sitenamewarn").html("A Site MUST have a Valid Name");
        sitecheck = false;
    }

    if (sitecheck == false) {
        return false;
    }
    else {
        alert("Site Created");
        return true;
    }
}

function EventCheck() {
    var currentdate = new Date().toISOString().slice(0,10);
    var eventCheck;
    var sitecode = $(".siteCode").val();
    var date = $(".Date").val();
    var spaces = parseInt($(".Spaces").val());

    if (sitecode == "" || sitecode.length <= 2) {
        $("#eventsitecodewarn").html("Please Enter A Valid Sitecode");
        eventCheck = false;
    }
    if (date == "" || date < currentdate) {
        $("#eventdatewarn").html("Please Enter A Valid Date");
        eventCheck = false;
    }
    if (spaces == "" || spaces < 1) {
        $("#eventspaceswarn").html("Please Enter a Valid Number of Spaces");
        eventCheck = false;
    }

    if (eventCheck == false) {
        return false;
    }
    else {
        alert("Event Created");
        return true;
    }
}