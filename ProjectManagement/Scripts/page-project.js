//Load Data in Table when documents is ready
$(document).ready(function () {
    loadData();
});
//Load Data function
function loadData() {
    $.ajax({
        url: "/Project/ListDataProject",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';

                html += '<td>' + item.ProjectName + '</td>';
                html += '<td>' + item.ClientName + '</td>';
                html += '<td>' + item.Description + '</td>';
                html += '<td>' + item.PIC + '</td>';
                html += '<td>' + item.ProjectStatusName + '</td>';

                html += '<td>' +
                                        'Start Date Plan____:  ' + item.StartDatePlanStr + '</br>' +
                                        'End Date Plan______:  ' + item.EndDatePlanStr + '</br>' +
                                        'Start Date Actual__:  ' + item.StartDateActualStr + '</br>' +
                                        'End Date Actual____:  ' + item.EndDateActualStr + '</br>' +
                                     '</td>';
                html += '<td><button onclick="return getbyID(' + item.ProjectId + ')" class="btn btn-info" >Edit</button></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert('error : ' + errormessage.responseText);
            //var c = errormessage.error;
            //$('.tbody').html(errormessage.getAllResponseHeaders.toString());
        }
    });
}

function Search() {
    var valueSearch = {
        ProjectName: $('#ProjectName').val(),
        FromDatePlan: $('#FromDatePlan').val(),
        ToDatePlan: $('#ToDatePlan').val(),
        EndFromDatePlan: $('#EndFromDatePlan').val(),
        EndToDatePlan: $('#EndToDatePlan').val(),
        ProjectStatusId: $('#ProjectStatusId').val(),
        ProjectName: $('#ProjectName').val(),
        ClientId: $('#ClientId').val(),
        FromDateActual: $('#FromDateActual').val(),
        ToDateActual: $('#ToDateActual').val(),
        PIC: $('#PIC').val(),
        EndFromDateActual: $('#EndFromDateActual').val(),
        EndToDateActual: $('#EndToDateActual').val()

    };
    $.ajax({
        url: "/Project/Search",
        data: JSON.stringify(valueSearch),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';

                html += '<td>' + item.ProjectName + '</td>';
                html += '<td>' + item.ClientName + '</td>';
                html += '<td>' + item.Description + '</td>';
                html += '<td>' + item.PIC + '</td>';
                html += '<td>' + item.ProjectStatusName + '</td>';

                html += '<td>' +
                                        'Start Date Plan____:  ' + item.StartDatePlanStr + '</br>' +
                                        'End Date Plan______:  ' + item.EndDatePlanStr + '</br>' +
                                        'Start Date Actual__:  ' + item.StartDateActualStr + '</br>' +
                                        'End Date Actual____:  ' + item.EndDateActualStr + '</br>' +
                                     '</td>';
                html += '<td><button onclick="return getbyID(' + item.ProjectId + ')" class="btn btn-info" >Edit</button></td>';
                html += '</tr>';
            }),
            $('.tbody').html(html);
            $('#ProjectName').val('');
            $('#FromDatePlan').val('');
            $('#ToDatePlan').val('');
            $('#EndFromDatePlan').val('');
            $('#EndToDatePlan').val('');
            $('#ProjectStatusId').val('');
            $('#ProjectName').val('');
            $('#ClientId').val('');
            $('#FromDateActual').val('');
            $('#ToDateActual').val('');
            $('#PIC').val('');
            $('#EndFromDateActual').val('');
            $('#EndToDateActual').val('');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}