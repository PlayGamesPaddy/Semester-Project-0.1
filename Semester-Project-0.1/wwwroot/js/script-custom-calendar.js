var routeURL = location.protocol + "//" + location.host;
$(document).ready(function () {
    kendo.culture("en-IE");
    $('#classDate').kendoDateTimePicker({
        value: new Date(),
        dateInput: false
    });
    $("#datepicker").kendoDatePicker({
        dateInput: true
    });
    $("#lastdatepicker").kendoDatePicker({
        dateInput: true
    });
    $("#montimepicker").kendoTimePicker({
        dateInput: true
    });
    $("#tuetimepicker").kendoTimePicker({
        dateInput: true
    });
    $("#wentimepicker").kendoTimePicker({
        dateInput: true
    });
    $("#thutimepicker").kendoTimePicker({
        dateInput: true
    });
    $("#fritimepicker").kendoTimePicker({
        dateInput: true
    });
    $("#sattimepicker").kendoTimePicker({
        dateInput: true
    });
    $("#suntimepicker").kendoTimePicker({
        dateInput: true
    });
    InitializeCalendar();
});

var calendar;
function InitializeCalendar() {
    try {
        //document.addEventListener('DOMContentLoaded', function () {
        var calendarEl = document.getElementById('calendar');
        if (calendarEl != null) { 
         calendar = new FullCalendar.Calendar(calendarEl, {
            initialView: 'dayGridMonth',
            headerToolbar: {
                left: 'prev,next,today',
                center: 'title',
                right: 'dayGridMonth,timeGridWeek,timeGridDay'
            },
            selectable: true,
            editable: false,
            select: function (event) {
                onShowModal(event, null);
            },
            eventDisplay:'block',
            events: function (fetchInfo, successCallback, failureCallback) {
                $.ajax({
                    url: routeURL + '/api/Class/GetCalendarData?InstructureId=' + $("#instructureId").val(),
                    type: 'GET',
                    dataType: 'JSON',
                    success: function (response) {
                        var events = [];
                        /*events.push({
                            _id: 100,
                            title: '23222instructureId=' + $("#instructureId").val(),
                            avatar: 'https://republika.mk/wp-content/uploads/2017/07/man-852762_960_720.jpg',
                            description: 'Lorem ipsum dolor sit incid idunt ut Lorem ipsum sit.',
                            start: '2022-02-21 09:30',
                            end: '2022-02-21 10:00',
                            type: 'Appointment',
                            username: 'Caio Vitorelli',
                            backgroundColor: "#f4516c",
                            textColor: "#ffffff",
                            allDay: false
                        });*/
                        if (response.status === 1) {
                            $.each(response.datenum, function (i, data) {
                            //for(let i = 0 ; i < response.dataenum.length; i++){
                                events.push({
                                    title: data.title,
                                    description: data.description,
                                    start: data.startDate,
                                    end: data.endDate,
                                    backgroundColor: data.isApproved ? "#28a745" : "#dc3545",
                                    borderColor: "#162466",
                                    textColor: "white",
                                    id: data.id
                                });

                            })

                        }


                        successCallback(events);
                    },
                    error: function (xhr) {
                        $.notify("Error", "error");
                    }
                });
            },
            eventClick: function (info) {
                getEventDetailsByEventId(info.event);
            }
        });
        calendar.render();
        }
    }
    catch (e) {
        alert(e);
    }
}

function onShowModal(obj, isEventDetail) {
    if (isEventDetail != null) {

        $("#title").val(obj.title);
        $("#id").val(obj.id);
        $("#classDate").val(obj.startDate);
        $("#description").val(obj.description);
        $("#duration").val(obj.duration);
        $("#instructureId").val(obj.instructerId);
        $("#studentId").val(obj.studentId);
        $("#lblInstructureName").html(obj.instructureName);
        $("#lblStudentName").html(obj.studentName);
        if (obj.isApproved) {
            $("#lblStatus").html('Approved');
            $("#btnConfirm").addClass("d-none");
            $("#btnSubmit").addClass("d-none");
        }
        else {
            $("#lblStatus").html('Pending');
            $("#btnSubmit").removeClass("d-none");
            $("#btnConfirm").removeClass("d-none");
        }
        $("#btnDelete").removeClass("d-none");
    }
    else {
        $("#classDate").val(obj.startStr + " " + new moment().format("hh:mm A"));
        $("#id").val(0);
        $("#btnDelete").addClass("d-none");
        $("#btnSubmit").removeClass("d-none");
    }
    $("#classInput").modal("show");
}

function onCloseModal() {
    $('#classForm')[0].reset();
    $("#title").val('');
    $("#id").val('');
    $("#classDate").val('');
    $("#description").val('');
    $("#classInput").modal("hide");
}

function onSubmitForm() {
    if (checkValidation()) {
        var requestData = {
            Id: parseInt($('#id').val()),
            Title: $("#title").val(),
            StartDate: $("#classDate").val(),
            Description: $("#description").val(),
            Duration: $("#duration").val(),
            InstructerId: $("#instructureId").val(),
            StudentId: $("#studentId").val(),
        };

        $.ajax({
            url: routeURL + '/api/Class/SaveCalendarData',
            type: 'POST',
            data: JSON.stringify(requestData),
            contentType: 'application/json',
            success: function (response) {
                if (response.status === 1 || response.status === 2) {
                    calendar.refetchEvents();
                    $.notify(response.message, "success");
                    onCloseModal();
                }
                else {
                    $.notify("1" + response.message, "error");
                    onCloseModal();
                }
            },
            error: function (xhr) {
                $.notify("Error", "error");
            }
        });
    }
}

function checkValidation() {
    var isValid = true;
    if ($("#title").val() === undefined || $("#title").val() === "" || $("#title").val() === " ") {
        isValid = false;
        $("#title").addClass('error');
    }
    else {
        $("#title").removeClass('error');
    }
    if ($("#classDate").val() === undefined || $("#classDate").val() === "" || $("#classDate").val() === " ") {
        isValid = false;
        $("#classDate").addClass('error');
    }
    else {
        $("#classDate").removeClass('error');
    }
    if ($("#description").val() === undefined || $("#description").val() === "" || $("#description").val() === " ") {
        isValid = false;
        $("#description").addClass('error');
    }
    else {
        $("#studentId").removeClass('error');
    }
    if ($("#studentId").val() === "Please select one" ) {
        isValid = false;
        $("#studentId").addClass('error');
    }
    else {
        $("#studentId").removeClass('error');
    }
    return isValid;
}

function getEventDetailsByEventId(info) {
    $.ajax({
        url: routeURL + '/api/class/GetCalendarDataById/' + info.id,
        type: 'GET',
        dataType: 'JSON',
        success: function (response) {

            if (response.status === 1 && response.datenum !== undefined) {
                onShowModal(response.datenum, true);
            }
            successCallback(events);
        },
        error: function (xhr) {
            $.notify("Error", "error");
        }
    });
}

function OnInstructerIdChange() {
    calendar.refetchEvents();
}

function onDeleteClass() {
    var id = parseInt($("#id").val());
    $.ajax({
        url: routeURL + '/api/class/DeleteClass/' + id,
        type: 'GET',
        dataType: 'JSON',
        success: function (response) {

            if (response.status === 1) {
                $.notify(response.message, "success")
                calendar.refetchEvents();
                onCloseModal();
            }
            else {
                $.notify(response.message, "error")
            }
        },
        error: function (xhr) {
            $.notify("Error", "error");
        }
    });
}

function onConfirm() {
    var id = parseInt($("#id").val());
    $.ajax({
        url: routeURL + '/api/class/ConfirmEvent/' + id,
        type: 'GET',
        dataType: 'JSON',
        success: function (response) {

            if (response.status === 1) {
                $.notify(response.message, "success")
                calendar.refetchEvents();
                onCloseModal();
            }
            else {
                $.notify(response.message, "error")
            }
        },
        error: function (xhr) {
            $.notify("Error", "error");
        }
    });
}