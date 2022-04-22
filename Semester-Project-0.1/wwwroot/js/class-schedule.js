var routeURL = location.protocol + "//" + location.host;



function showStudentPopUp(IDIn) {
    $("#recurringClassInstentId").val(IDIn);
    $("#addStudentToClass").modal("show");
}

function closeStudentPopUp() {
    $("#addStudentToClass").modal("hide");
}


function RClassDelete(){
    $.notify("Class Deleted ", "success")
}

function enroleStudent() {
    var requestData = {
        //id: parseInt($('#classStudentListId').val()),
        studentId: $("#studentId").val(),
        recurringClassInstentId: $("#recurringClassInstentId").val()
    };

    $.ajax({
        url: routeURL + '/api/RecurringClassSetup/EnrollStudent',
        type: 'POST',
        data: JSON.stringify(requestData),
        contentType: 'application/json',
        success: function (response) {
            if (response.status === 1 || response.status === 2) {
                $.notify(response.message, "success");
                window.location.href = '/Class/RecurringClassInfo/' + requestData.recurringClassInstentId   ;
            }
            if (response.status === 3) {
                $.notify(response.message, "error");
            }
            else {
                $.notify("1" + response.message, "error");
            }
        },
        error: function (xhr) {
            $.notify("Error/ssdsdsd", "error");
        }
    });
}

function unenroleStudent( sid, rcid) {
    var requestData = {
        //id: parseInt($('#classStudentListId').val()),
        studentId: sid,
        recurringClassInstentId: rcid
    };

    $.ajax({
        url: routeURL + '/api/RecurringClassSetup/unEnrollStudent',
        type: 'POST',
        data: JSON.stringify(requestData),
        contentType: 'application/json',
        success: function (response) {
            if (response.status === 1 || response.status === 2) {
                $.notify(response.message, "success");
                //window.location.href = '/Class/RecurringClassInfo/' + requestData.recurringClassInstentId;
            }
            else {
                $.notify("1" + response.message, "error");
            }
        },
        error: function (xhr) {
            $.notify("Error/ssdsdsd", "error");
        }
    });
}



function addComment() {
    var requestData = {
        ClassStudentListid: $("#ClassStudentListid").val(),
        Text: $("#textAreaComment").val()
    };

    $.ajax({
        url: routeURL + '/api/RecurringClassSetup/addComment',
        type: 'POST',
        data: JSON.stringify(requestData),
        contentType: 'application/json',
        success: function (response) {
            if (response.status === 1 || response.status === 2) {
                $.notify(response.message, "success");
            }
            else {
                $.notify("1" + response.message, "error");
            }
        },
        error: function (xhr) {
            $.notify("Error/ssdsdsd", "error");
        }
    });
}

function showTable(Table){
    //$("#" + Table).modal("show");
    //document.getElementById(Table);
    if (document.getElementById(Table).style.display == 'none') {
        document.getElementById(Table).style.display = 'block'; //show


        document.getElementById(Table + '+').style.display = 'none';
        document.getElementById(Table + '-').style.display = 'block';
    }
    else {
        document.getElementById(Table).style.display = 'none';  // to hide

        document.getElementById(Table + '+').style.display = 'block';
        document.getElementById(Table + '-').style.display = 'none';
    }
}