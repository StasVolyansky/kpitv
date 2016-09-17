$(document).ready(function () {
    $(".form-stuff > form > img").click(function () {
        $(".form-stuff > form > input[type=file]").click();
        //if ($(".form-stuff > form > input[type=file]").val() != "")
            //showFile();
            //$(".form-stuff > form > img").attr("src", $(".form-stuff > form > input[type=file]").val())
    });
    $(".form-stuff > form > input[type=file]").change(showFile);
});

function showFile(e) {
    var file = e.target.files[0];
    if (!file.type.match('image.*')) {
        var fileReader = new FileReader();
        fileReader.onload = (function (theFile) {
            return function (e) {
                var li = document.createElement('li');
                li.innerHTML = "<img src='" + e.target.result + "' />";
                document.getElementById('list').insertBefore(li, null);
            };
        })(file);
        fileReader.readAsDataURL(file);
    }
}

