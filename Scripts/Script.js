﻿function getInfo(id)
{
    var str = document.getElementById("id_os")[id-1].label;
    var arr = str.split(',');
    id = arr[0];
    var d;
    $.ajax({
        url: '/api/lastcosts/' + id,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            d = JSON.parse(data);
            document.getElementById("wearrate").innerHTML = d.wearrate; 
            document.getElementById("lastcost").innerHTML = d.lastCost; 
            document.getElementById("recomendedCost").innerHTML = d.recCost;
        },
        error: function (p1, p2, p3) {
            alert(p1 + '\n' + p2 + '\n' + p3);
        }
    });
}
function getOsCard(id)
{
    var str = document.getElementById("id_os")[id - 1].label;

    var arr = str.split(',');
    id = arr[0];
    var d;
    $.ajax({
        url: '/api/cardOS/' + id,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            d = JSON.parse(data);
            document.getElementById("class").innerHTML = d.class1;
            document.getElementById("os_name").innerHTML = d.os_name;
            document.getElementById("invertory_number").innerHTML = d.invertory_number;
            document.getElementById("wearrate").innerHTML = d.wearrate;
            document.getElementById("service_start").innerHTML = d.service_start;
            document.getElementById("service_time").innerHTML = d.service_time;
            document.getElementById("unit").innerHTML = d.unit;
            document.getElementById("lastcost").innerHTML = d.lastcost;
            document.getElementById("pin_date").innerHTML = d.pin_date;
            document.getElementById("molname").innerHTML = d.mol;
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}
function getReportOS(id)
{
    var str = document.getElementById("id_os")[id - 1].label;

    var arr = str.split(',');
    id = arr[0];
    var html = "https://" + window.location.host + "/Functions/ReportOSid/" + id;
    window.location.replace(html);

}
function getReportMOL(id) {
    var str = document.getElementById("id_mol")[id - 1].label;

    var arr = str.split(',');
    id = arr[0];
    var html = "https://" + window.location.host + "/Functions/ReportMOLid/" + id;
    window.location.replace(html);

}