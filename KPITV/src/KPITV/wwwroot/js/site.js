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

$(document).ready(function () {
    $(".settings-info input").change(function () {
        $.ajax({
            method: "post",
            url: "settings",
            data: {
                param: $(this).attr("name"),
                value: $(this).val()
            }
        });
    });
});

function IsMember() {
    $.ajax({
        method: "post",
        url: "https://api.vk.com/method/groups.getMembers",
        data: {
            group_id: "kpitvhome",
            version: "5.27"
        },
        dataType: "json",
        success: function (data) {
            alert(data);
        }
    });
}
