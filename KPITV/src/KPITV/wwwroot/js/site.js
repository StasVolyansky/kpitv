$(document).on({
    ajaxStart: StartLoading,
    ajaxStop: StopLoading
});

function StartLoading() {
    $(".loading-animation").css({ "display": "block" });
    $("body").addClass("loading");
}

function StopLoading() {
    $(".loading-animation").css({ "display": "none" });
    $("body").removeClass("loading");
}

function LogOff() {
    document.getElementById('logoutForm').submit();
}

function LogFB() {
    $('#logFBForm').submit();
}

function UploadSettings() {
    $.ajax({
        method: "post",
        url: "settings",
        data: {
            param: $(this).attr("name"),
            value: $(this).val()
        }
    });
}

$(document).ready(function () {
    $(".profile-photo img").click(function () {
        $(".profile-photo input").click();
        if ($(".profile-photo input").val() != "")
            $(".profile-photo form").submit();
    });

    $(".settings-info input").change(UploadSettings());
});

