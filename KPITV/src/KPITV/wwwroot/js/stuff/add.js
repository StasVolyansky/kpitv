$(document).ready(function () {
    $(".form-stuff > form > img").click(function () {
        $(".form-stuff > form > input[type=file]").click();
        //if ($(".form-stuff > form > input[type=file]").val() != "")
        //    $(".form-stuff > form > img").attr("src", getFileLink())
    });

    //add/change type

    $("#selectType").change(function () {
        if ($(this).val() == "add") { // если выбран add
            $("#addType").css("display", "inherit");
            console.log("выбран add");
            if ($("#addType input").val() != "") { // и при этом поле не пусто
                $("#selectType").removeAttr("name");
                $("#addType input").attr("name", "type");
                console.log("поле не пусто");
            }
            else { // и при этом поле пусто
                console.log("поле пусто");
            }
        }
        else { // если выбрано любое не-add
            $("#addType").css("display", "none");
            $("#addType input").removeAttr("name");
            $(this).attr("name", "type");
            console.log("выбрано не-add");
        }
    });

    $("#addType input").change(function () { // если изменилось поле
        console.log("изменилось поле");
        if ($("#addType input").val() != "") { // и при этом поле не пусто
            $("#selectType").removeAttr("name");
            $(this).attr("name", "type");
            console.log("поле не пусто");
        }
        else {// и при этом поле пусто
            $("#selectType").attr("name", "type");
            $(this).removeAttr("name");
            console.log("поле пусто");
        }
    });

    if ($("#selectType").val() == "add")
        $("#selectType").change();

    
    // add/change owner

    $("#selectOwner").change(function () {
        if ($(this).val() == "add") { // если выбран add
            $("#addOwner").css("display", "inherit");
            console.log("выбран add");
            if ($("#addOwner input").val() != "") { // и при этом поле не пусто
                $("#selectOwner").removeAttr("name");
                $("#addOwner input").attr("name", "owner");
                console.log("поле не пусто");
            }
            else { // и при этом поле пусто
                console.log("поле пусто");
            }
        }
        else { // если выбрано любое не-add
            $("#addOwner").css("display", "none");
            $("#addOwner input").removeAttr("name");
            $(this).attr("name", "owner");
            console.log("выбрано не-add");
        }
    });

    $("#addOwner input").change(function () { // если изменилось поле
        console.log("изменилось поле");
        if ($("#addOwner input").val() != "") { // и при этом поле не пусто
            $("#selectOwner").removeAttr("name");
            $(this).attr("name", "owner");
            console.log("поле не пусто");
        }
        else {// и при этом поле пусто
            $("#selectOwner").attr("name", "owner");
            $(this).removeAttr("name");
            console.log("поле пусто");
        }
    });

    if ($("#selectOwner").val() == "add")
        $("#selectOwner").change();


});

function getFileLink(e) {
    var file = e.target.files[0];
    //if (!file.type.match('image.*')) {
    //    var fileReader = new FileReader();
    //    fileReader.onload = (function (theFile) {
    //        return function (e) {
    //            var li = document.createElement('li');
    //            li.innerHTML = "<img src='" + e.target.result + "' />";
    //            document.getElementById('list').insertBefore(li, null);
    //        };
    //    })(file);
    //    fileReader.readAsDataURL(file);
    //}
    return e.target.result;
}

