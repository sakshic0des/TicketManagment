window.addEventListener("DOMContentLoaded", function () {
    overrideLoading = setTimeout(function () {
        EndLoading();
    }, 2000); //Delay just used for example and must be set to 0.
});

function ShowLoading() {
    $("#waitContainer").css("display", "block")
}

function EndLoading() {
    $("#waitContainer").css("display", "none")
}

function FormDataToJSON(FormElement) {
    var formData = new FormData(FormElement);
    var ConvertedJSON = {};
    for (const [key, value] of formData.entries()) {
        if (typeof (value) == "string") {
            ConvertedJSON[key] = value.trim();
        }
    }
    return ConvertedJSON
}
function ShowComfirmationModel(msg) {
    let $mymodal = $("#MessageModal");
    //update the modal's body with the response received
    var body = `<h1 class="ConfirmTitle">Confirmation</h1>
					<p class="ConfirmPara">${msg}</p>
					<button type="button" id="confirmationBtnYes" class="btn btn-primary text-white FormBTN">Yes</button>
					<button type="button" id="confirmationBtnCancel" class="btn btn-inverse btn waves-effect waves-light btn-outline-info FormBTN" data-bs-dismiss="modal">No</button>`;

    $mymodal.find("div.modal-body").html(body);
    // Show the modal
    $mymodal.modal("show");

    return false;
}
function CheckFileValidation(obj, extension, errorMsg, spanExtensionId = "FileExtensionError", spanSizeId = "FileSizeError") {
    var IsValid = 0;
    var fileInput = obj[0];
    var fileName = fileInput.files[0].name.replace(/ /g, "");
    var fileSize = fileInput.files[0].size;
    var ext = fileName.match(/\.([^\.]+)$/)[1];
    if (!extension.includes(ext.toLowerCase())) {
        $("#" + spanExtensionId).text(errorMsg).show()
        $("#" + obj.id).val('');
    }
    else {
        IsValid++;
        $("#" + spanExtensionId).hide();
    }
    if (fileSize > 5242880) {
        $("#" + spanSizeId).text("File Size Can't Be Greater Than 5MB!").show()
        $("#" + obj.id).val('');
    }
    else {
        IsValid++;
        $("#" + spanSizeId).hide();
    }

    if (IsValid == 2) return true;

    return false;
}


