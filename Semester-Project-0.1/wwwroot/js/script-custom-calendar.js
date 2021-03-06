var routeURL = location.protocol + "//" + location.host;
$(document).ready(function () {
    kendo.culture("en-IE");
    $('#classDate').kendoDateTimePicker({
        value: new Date(),
        dateInput: false
    });
    $("#datepicker").kendoDatePicker({
        dateInput: false
    });
    $("#lastdatepicker").kendoDatePicker({
        dateInput: false
    });
    $("#montimepicker").kendoTimePicker({
        dateInput: false
    });
    $("#tuetimepicker").kendoTimePicker({
        dateInput: false
    });
    $("#wentimepicker").kendoTimePicker({
        dateInput: false
    });
    $("#thutimepicker").kendoTimePicker({
        dateInput: false
    });
    $("#fritimepicker").kendoTimePicker({
        dateInput: false
    });
    $("#sattimepicker").kendoTimePicker({
        dateInput: false
    });
    $("#suntimepicker").kendoTimePicker({
        dateInput: false
    });
    $("#weeklytimepicer").kendoTimePicker({
        dateInput: false
    });
    $("#secondweeklytimepicer").kendoTimePicker({
        dateInput: false
    });
    $("#mounthtimepicer").kendoTimePicker({
        dateInput: false
    });
    InitializeCalendar();
    InitializeRClassCalendar();
    InitializeStudentClassCalendar();
    InitializeInstructureCalendar();
    schedulingType();
    MultibleDayCB();
});

var calendar;
var calendar2;
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


function InitializeRClassCalendar() {
    try {
        //document.addEventListener('DOMContentLoaded', function () {
        var calendarEl = document.getElementById('calendar2');
        if (calendarEl != null) {
            calendar2 = new FullCalendar.Calendar(calendarEl, {
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
                eventDisplay: 'block',
                events: function (fetchInfo, successCallback, failureCallback) {
                    $.ajax({
                        url: routeURL + '/api/RecurringClassSetup/GetRecurringClassesCalendarData?recurringClassId=' + $("#RCId").val(),
                        type: 'GET',
                        dataType: 'JSON',
                        success: function (response) {
                            var events = [];
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
            calendar2.render();
        }
    }
    catch (e) {
        alert(e);
    }
}

function InitializeInstructureCalendar() {
    try {
        //document.addEventListener('DOMContentLoaded', function () {
        var calendarEl = document.getElementById('calendarInstructure');
        if (calendarEl != null) {
            calendarInstructure = new FullCalendar.Calendar(calendarEl, {
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
                eventDisplay: 'block',
                events: function (fetchInfo, successCallback, failureCallback) {
                    $.ajax({
                        url: routeURL + '/api/RecurringClassSetup/GetInstructureClasses',
                        type: 'GET',
                        dataType: 'JSON',
                        success: function (response) {
                            var events = [];
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
            calendarInstructure.render();
        }
    }
    catch (e) {
        alert(e);
    }
}

function InitializeStudentClassCalendar() {
    try {
        //document.addEventListener('DOMContentLoaded', function () {
        var calendarEl = document.getElementById('studentCalendar');
        if (calendarEl != null) {
            studentCalendar = new FullCalendar.Calendar(calendarEl, {
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
                eventDisplay: 'block',
                events: function (fetchInfo, successCallback, failureCallback) {
                    $.ajax({
                        url: routeURL + '/api/RecurringClassSetup/GetStudentClasses',
                        type: 'GET',
                        dataType: 'JSON',
                        success: function (response) {
                            var events = [];
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
            studentCalendar.render();
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
        $("#Duration").val(obj.duration);
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
        $("#PUbtnDelete").removeClass("d-none");
    }
    else {
        $("#classDate").val(obj.startStr + " " + new moment().format("hh:mm A"));
        $("#id").val(0);
        $("#PUbtnDelete").addClass("d-none");
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
    var pageNo;
    pageNo = $("#pageNo").val();
    if (checkValidation()) {
        var Rcid;
        if ($("#RCId").val() == "" || $("#RCId").val() == null) {
            Rcid = null;
        }
        else {
            Rcid = $("#RCId").val();
        }
        var requestData = {
            Id: parseInt($('#id').val()),
            Title: $("#title").val(),
            StartDate: $("#classDate").val(),
            Description: $("#description").val(),
            Duration: $("#duration").val(),
            InstructerId: $("#instructureId").val(),
            StudentId: 0,
            RecurringClassInstentId: Rcid
        };

        $.ajax({
            url: routeURL + '/api/Class/SaveCalendarData',
            type: 'POST',
            data: JSON.stringify(requestData),
            contentType: 'application/json',
            success: function (response) {
                if (response.status === 1 || response.status === 2) {
                    if (pageNo == 1) {
                        calendar.refetchEvents();
                    }
                    else if (pageNo == 2) {
                        calendar2.refetchEvents();
                        $("#classTable").load(window.location.href + " #classTable");
                    }
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
/*
Id: parseInt($('#id').val()),
            Title: $("#Title").val(),
            FirstClassDate: $("#datepicker").val(),
            LastClassDate: $("#lastdatepicker").val(),
            Description: $("#Description").val(),
            Duration: $("#Duration").val(),
            InstructerId: $("#instructureId").val(),
            MaxNumberOfStudents: $("#MaxNumberOfStudents").val(),
            RecurringType: radioselected, */
function updateRC() {
    var getRequestData = {
        Id: $('#RCId').val(),
        Title: $("#Title").val(),
        Description: $("#Description").val(),
        InstructerId: $("#instructureId").val(),
        MaxNumberOfStudents: $("#MaxNumberOfStudents").val(),
        FirstClassDate: $('#FirstClassDate').val(),
        LastClassDate: $('#LastClassDate').val(),
        RecurringType: $('#RecurringType').val(),
    };

    $.ajax({
        url: routeURL + '/api/RecurringClassSetup/UpdateCalendarData',
        type: 'POST',
        data: JSON.stringify(getRequestData),
        contentType: 'application/json',
        success: function (response) {
            if (response.status >= 0) {
                $.notify(response.message, "success");
                window.location.href = '/Class/RecurringClassInfo/' + response.status;
            }
            else {
                $.notify("1" + response.message, "error");
            }
        },
        error: function (xhr) {
            $.notify("Error", "error");
        }
    });


}
function rClassSubmit() {
    var radioselected;
    var monday = false;
    var tuesday = false;
    var wednesday = false;
    var thursday = false;
    var friday = false;
    var saterday = false;
    var sunday = false;
    if (rClassCheckValidation()) {
        if (document.getElementById('Radios1').checked) {
            radioselected = $("#Radios1").val();
        }
        else if (document.getElementById('Radios2').checked) {
            radioselected = $("#Radios2").val();


            if (document.getElementById('cbMonday').checked) { monday = true; }
            if (document.getElementById('cbTuesday').checked) { tuesday = true; }
            if (document.getElementById('cbWednesday').checked) { wednesday = true; }
            if (document.getElementById('cbThursday').checked) { thursday = true; }
            if (document.getElementById('cbFriday').checked) { friday = true; }
            if (document.getElementById('cbSaturday').checked) { saterday = true; }
            if (document.getElementById('cbSunday').checked) { sunday = true; }



        }
        else if (document.getElementById('Radios3').checked) {
            radioselected = $("#Radios3").val();
        }
        else {
            radioselected = $("#Radios4").val();
        }



        var requestData = {
            Title: $("#Title").val(),
            FirstClassDate: $("#datepicker").val(),
            LastClassDate: $("#lastdatepicker").val(),
            Description: $("#Description").val(),
            Duration: $("#Duration").val(),
            InstructerId: $("#instructureId").val(),
            MaxNumberOfStudents: $("#MaxNumberOfStudents").val(),
            RecurringType: radioselected,

            weeklyday: $("#weeklyday").val(),
            weeklytimepicer: $("#weeklytimepicer").val(),

            cbMonday: monday,
            montimepicker: $("#montimepicker").val(),
            cbTuesday: tuesday,
            tuetimepicker: $("#tuetimepicker").val(),
            cbWednesday: wednesday,
            wentimepicker: $("#wentimepicker").val(),
            cbThursday: thursday,
            thutimepicker: $("#thutimepicker").val(),
            cbFriday: friday,
            fritimepicker: $("#fritimepicker").val(),
            cbSaturday: saterday,
            sattimepicker: $("#sattimepicker").val(),
            cbSunday: sunday,
            suntimepicker: $("#suntimepicker").val(),

            secondweekdaysoftheweekradio: $("#secondweekdaysoftheweekradio").val(),
            secondweeklytimepicer: $("#secondweeklytimepicer").val(),

            onceaMonthradio: $("#onceaMonthradio").val(),
            mounthtimepicer: $("#mounthtimepicer").val(),
        };

        $.ajax({
            url: routeURL + '/api/RecurringClassSetup/SaveCalendarData',
            type: 'POST',
            data: JSON.stringify(requestData),
            contentType: 'application/json',
            success: function (response) {
                if (response.status >= 0) {
                    $.notify(response.message, "success");
                    window.location.href = '/Class/RecurringClassInfo/' + response.status;
                }
                else {
                    $.notify("1" + response.message, "error");
                }
            },
            error: function (xhr) {
                $.notify("Error", "error");
            }
        });
    }
    else {
        $.notify("Please fill in all required feilds", "error");
    }
}
function rClassCheckValidation() {
    var isValid = true;
    if ($("#Title").val() === undefined || $("#Title").val() === "" || $("#Title").val() === " ") {
        isValid = false;
        $("#Title").addClass('error');
    }
    else {
        $("#Title").removeClass('error');
    }
    if ($("#MaxNumberOfStudents").val() === undefined || $("#MaxNumberOfStudents").val() === "" || $("#MaxNumberOfStudents").val() === " ") {
        isValid = false;
        $("#MaxNumberOfStudents").addClass('error');
    }
    else {
        $("#MaxNumberOfStudents").removeClass('error');
    }
    if ($("#Description").val() === undefined || $("#Description").val() === "" || $("#Description").val() === " ") {
        isValid = false;
        $("#Description").addClass('error');
    }
    else {
        $("#Description").removeClass('error');
    }
    if ($("#datepicker").val() === undefined || $("#datepicker").val() === "" || $("#datepicker").val() === " ") {
        isValid = false;
        $("#datepicker").addClass('error');
    }
    else {
        $("#datepicker").removeClass('error');
    }
    if ($("#lastdatepicker").val() === undefined || $("#lastdatepicker").val() === "" || $("#lastdatepicker").val() === " ") {
        isValid = false;
        $("#lastdatepicker").addClass('error');
    }
    else {
        $("#lastdatepicker").removeClass('error');
    }
    if (document.getElementById('Radios2').checked) {
        if (document.getElementById('cbMonday').checked == false & document.getElementById('cbTuesday').checked == false & document.getElementById('cbWednesday').checked == false & document.getElementById('cbThursday').checked == false & document.getElementById('cbFriday').checked == false & document.getElementById('cbSaturday').checked == false & document.getElementById('cbSunday').checked == false) {
            $("#multidayweekPanel").addClass('error');
            isValid = false;
        }
        else {
            $("#multidayweekPanel").removeClass('error');
        }
        if (document.getElementById('cbMonday').checked == true & ($("#montimepicker").val() === undefined || $("#montimepicker").val() === "")) {
            $("#montimepicker").addClass('error');
        }
        else {
            $("#montimepicker").removeClass('error');
        }
        if (document.getElementById('cbTuesday').checked == true & ($("#tuetimepicker").val() === undefined || $("#tuetimepicker").val() === "")) {
            $("#tuetimepicker").addClass('error');
        }
        else {
            $("#tuetimepicker").removeClass('error');
        }
        if (document.getElementById('cbWednesday').checked == true & ($("#wentimepicker").val() === undefined || $("#wentimepicker").val() === "")) {
            $("#wentimepicker").addClass('error');
        }
        else {
            $("#wentimepicker").removeClass('error');
        }
        if (document.getElementById('cbThursday').checked == true & ($("#thutimepicker").val() === undefined || $("#thutimepicker").val() === "")) {
            $("#thutimepicker").addClass('error');
        }
        else {
            $("#thutimepicker").removeClass('error');
        }
        if (document.getElementById('cbFriday').checked == true & ($("#fritimepicker").val() === undefined || $("#fritimepicker").val() === "")) {
            $("#fritimepicker").addClass('error');
        }
        else {
            $("#fritimepicker").removeClass('error');
        }
        if (document.getElementById('cbSaturday').checked == true & ($("#sattimepicker").val() === undefined || $("#sattimepicker").val() === "")) {
            $("#sattimepicker").addClass('error');
        }
        else {
            $("#sattimepicker").removeClass('error');
        }
        if (document.getElementById('cbSunday').checked == true & ($("#suntimepicker").val() === undefined || $("#suntimepicker").val() === "")) {
            $("#suntimepicker").addClass('error');
        }
        else {
            $("#suntimepicker").removeClass('error');
        }

    }
    if (document.getElementById('Radios1').checked) {
        if ($("#weeklytimepicer").val() === undefined || $("#weeklytimepicer").val() === "") {
            $("#weeklytimepicer").addClass('error');
        }
        else {
            $("#weeklytimepicer").removeClass('error');
        }
    }
    if (document.getElementById('Radios3').checked) {
        if ($("#secondweeklytimepicer").val() === undefined || $("#secondweeklytimepicer").val() === "") {
            $("#secondweeklytimepicer").addClass('error');
        }
        else {
            $("#secondweeklytimepicer").removeClass('error');
        }
    }
    if (document.getElementById('Radios4').checked) {
        if ($("#mounthtimepicer").val() === undefined || $("#mounthtimepicer").val() === "") {
            $("#mounthtimepicer").addClass('error');
        }
        else {
            $("#mounthtimepicer").removeClass('error');
        }
    }
    return isValid;
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

function onDeleteClassPopup() {
    var id = parseInt($("#id").val());
    var pageNo = $("#pageNo").val();
    $.ajax({
        url: routeURL + '/api/class/DeleteClass/' + id,
        type: 'GET',
        dataType: 'JSON',
        success: function (response) {

            if (response.status === 1) {
                $.notify(response.message, "success")
                if (pageNo == 1) {
                    calendar.refetchEvents();
                }
                else if (pageNo == 2) {
                    calendar2.refetchEvents();
                }
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
function onDeleteClass(idin) {
    var id = idin;
    var pageNo = $("#pageNo").val();
    $.ajax({
        url: routeURL + '/api/class/DeleteClass/' + id,
        type: 'GET',
        dataType: 'JSON',
        success: function (response) {

            if (response.status === 1) {
                $.notify(response.message, "success")
                if (pageNo == 1) {
                    calendar.refetchEvents();
                }
                else if (pageNo == 2) {
                    calendar2.refetchEvents();
                    $("#classTableDiv").load(window.location.href + " #classTableDiv");
                }
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
                if (pageNo == 1) {
                    calendar.refetchEvents();
                }
                else if (pageNo == 2) {
                    calendar2.refetchEvents();
                }
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

function schedulingType() {
    $("#weeklyDiv").hide();
    $("#multidayweekPanel").hide();
    $("#secondweekDiv").hide();
    $("#onceaMonthpanel").hide();
    if (document.getElementById('Radios1').checked) {
        $("#weeklyDiv").removeClass('hide');
        $("#weeklyDiv").show();
    }
    else if (document.getElementById('Radios2').checked) {
        $("#multidayweekPanel").removeClass('hide');
        $("#multidayweekPanel").show();
    }
    else if (document.getElementById('Radios3').checked) {
        $("#secondweekDiv").removeClass('hide');
        $("#secondweekDiv").show();
    }
    else if (document.getElementById('Radios4').checked) {
        $("#onceaMonthpanel").removeClass('hide');
        $("#onceaMonthpanel").show();
    }
}

function MultibleDayCB() {
    $("#tuediv").hide();
    $("#mondiv").hide();
    $("#wendiv").hide();
    $("#thudiv").hide();
    $("#fridiv").hide();
    $("#satdiv").hide();
    $("#sundiv").hide();
    if (document.getElementById('cbMonday').checked) {

        $("#mondiv").removeClass('hide');
        $("#mondiv").show();
    }
    if (document.getElementById('cbTuesday').checked) {

        $("#tuediv").removeClass('hide');
        $("#tuediv").show();
    }
    if (document.getElementById('cbWednesday').checked) {

        $("#wendiv").removeClass('hide');
        $("#wendiv").show();
    }
    if (document.getElementById('cbThursday').checked) {

        $("#thudiv").removeClass('hide');
        $("#thudiv").show();
    }
    if (document.getElementById('cbFriday').checked) {

        $("#fridiv").removeClass('hide');
        $("#fridiv").show();
    }
    if (document.getElementById('cbSaturday').checked) {

        $("#satdiv").removeClass('hide');
        $("#satdiv").show();
    }
    if (document.getElementById('cbSunday').checked) {

        $("#sundiv").removeClass('hide');
        $("#sundiv").show();
    }

   
}




function mouseOver(divin) {
    document.getElementById('' + divin + '').style.backgroundColor = 'blueviolet';
}

function mouseOut(divin) {
    document.getElementById(''+divin+'').style.backgroundColor = 'transparent';
}
