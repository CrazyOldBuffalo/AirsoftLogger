function SiteCheck() {
    var sitecheck;
    var sitecode = $(".siteCode").val();
    var city = $(".City").val();
    var tel = $(".Tel").val();
    var postcode = $(".PostCode").val();
    var sitename = $(".siteName").val();

    if (sitecode == "") {
        $("#sitecodewarn").html("A Site MUST have a Sitecode");
        sitecheck = false;
    }
    if (city == "") {
        $("#sitecitywarn").html("A Site MUST have a City");
        sitecheck = false;
    }
    if (tel == "") {
        $("#sitetelwarn").html("A Site MUST have a Contact Number");
        sitecheck = false;
    }
    if (postcode == "") {
        $("#sitepostcodewarn").html("A Site MUST have a Postcode");
        sitecheck = false;
    }
    if (sitename == "") {
        $("#sitenamewarn").html("A Site MUST hava a Name");
        sitecheck = false;
    }

    if (sitecheck == false) {
        return false;
    }
    else {
        return true;
    }
}

