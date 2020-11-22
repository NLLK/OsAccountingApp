function getInfo(id)
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
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });


}