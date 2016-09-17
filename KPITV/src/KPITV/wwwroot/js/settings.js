$(document).ready(function () {
    $(".profile-photo img").click(function () {
        $(".profile-photo input").click();
        if ($(".profile-photo input").val() != "")
            $(".profile-photo form").submit();
    });
    $(".settings-info input").change(UploadSettings());
});

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