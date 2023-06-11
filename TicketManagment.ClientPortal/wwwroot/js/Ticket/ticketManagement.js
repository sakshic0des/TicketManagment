
$(document).ready(function () {
    ShowLoading()

    // For select 2
    $(".select2").select2();
    $('.Select2WithoutSearch').select2({
        minimumResultsForSearch: -1
    });
    
    LoadAllTicketsDataTable();

    $('#departmentList').change(function () {
        debugger
        $("#employessList").empty();
        var departmentId = $("#departmentList").val();
        if (departmentId != "") {
            $.ajax({
                url: "/Ticket/RetrieveEmployessByDepartmentId",
                type: 'POST',
                dataType: "json",
                data: { 'departmentId': departmentId },
                success: function (data) {
                    if (data.succeded == "succeded") {
                        debugger
                        $("#employessList").append("<option value=\"" + "\">" + "Select Employee Name" + "</option>");
                        $.each(data.data, function (key, item) {
                            $("#employessList").append("<option value=\"" + item.id + "\">" + item.name + "</option>");
                        });
                    }
                },
                error: function () {
                    toastr["error"]("Error occurred");
                    setTimeout(function () {
                        EndLoading();
                    }, 500);
                }
            });
        }
    });
    $(".select2").select2().change(function () {
        $(this).valid();
    });
});
function redirectToCreatCoursePage() {
    ShowLoading();
    $.ajax({
        type: 'POST',
        url: `/Ticket/RetrieveDepartments`,
        success: function (data) {
            debugger
            $("#departmentList").empty();
            $("#departmentList").append("<option value=\"" + "\">" + "Select Department Name" + "</option>");
            $.each(data.data, function (key, item) {
                $("#departmentList").append("<option value=\"" + item.id + "\">" + item.name + "</option>");
                $("#departmentList").val($("#stausesList option:first").val()).change();
            });
            EndLoading();
             $('#CreateTicketModal').modal('show');
        },
        error: function () { EndLoading(); }
    });
}

$(document).on("click", "#addTicketBtn", function (e) {
    e.preventDefault();
    var form = $("#createTicketForm");
    form.validate();
    if (form.valid()) {
        $('#CreateTicketModal').modal('hide');
        ShowComfirmationModel("Are you sure you want to add this Ticket?");
        $("#confirmationBtnYes").removeAttr("onclick");
        $("#confirmationBtnYes").attr("onclick", `AddNewTicket()`);
    }
});

function AddNewTicket() {
    $('#MessageModal').modal('hide');
    $('#TakeActionModal').modal('hide');
    ShowLoading();
    debugger
    var model = FormDataToJSON(document.getElementById("createTicketForm"));
    var departmentId = $("#departmentList  :selected").val();
    var employeeId = $("#employessList  :selected").val();
    model.DepartmentId = departmentId;
    model.EmployeeId = employeeId
    $.ajax({
        url: "/Ticket/CreateTicket",
        type: 'POST',
        dataType: "json",
        data: { 'model': model },
        success: function (data) {
            if (data.succeded == "succeded") {
                $('#TakeActionModal').modal('hide');
                $.ajax({
                    url: '/Ticket/PartialTicketList',
                    type: "POST",
                    success: function (resHtml) {
                        resetForm();
                        $("#divResponse").html(resHtml);
                        LoadAllTicketsDataTable();
                        $("body").tooltip({ selector: '[data-toggle=tooltip]' });
                        setTimeout(function () {
                            EndLoading();
                        }, 500);
                        toastr.success("Ticket Added  successfully");
                    }
                });
            }
        },
        error: function () {
            toastr["error"]("Error occurred while adding new ticket");
            EndLoading();
        }
    });
}
function LoadAllTicketsDataTable() {
    ShowLoading();
    debugger
    let columns = [
        {
            render: function (data, type, row, meta) {
                if (row.projectName == null) {
                    return 'N/A'
                }
                return `${row.projectName}`;
            }
        },
        {
            render: function (data, type, row, meta) {
                if (row.departmentName == null) {
                    return 'N/A'
                }
                return `${row.departmentName}`;
            }
        },
        {
            render: function (data, type, row, meta) {
                if (row.description == null) {
                    return 'N/A'
                }
                return `${row.description}`;
            }
        },
        {
            render: function (data, type, row, meta) {
                if (row.requestedDate == null) {
                    return 'N/A'
                }
                return `${row.requestedDate}`;
            }
        },

    ];
    $('#ticketTable').DataTable({
        "paging": true,
        "ordering": true,
        "filter": true,
        "destroy": true,
        "orderMulti": false,
        "serverSide": true,
        "Processing": true,
        "searching": true,
        "columns": columns,
        "ajax":
        {
            "url": "/Ticket/GetAllTicketsAsJson",
            "type": "POST",
            "dataType": "JSON",
            "data": function (d) {
                ShowLoading();
            },
            "dataSrc": function (json) {
                setTimeout(function () {
                    EndLoading();
                }, 500);
                return json.data;
            },
            "error": function (jqXHR, ajaxOptions, thrownError) {
                EndLoading();
            },
        },
        "language": {
            "search": "Search:",
        },
    });
}

function resetForm() {
    $("input,textarea,select").val('');
    $(".ValidationError").text('');
}