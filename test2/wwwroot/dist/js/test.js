document.addEventListener("DOMContentLoaded", function() {
    $.ajax({
        url: 'https://api.jsonbin.io/v3/b/6651a59aad19ca34f86ecb8f',
        method: 'GET',
        headers: {
            'X-Master-Key': '$2a$10$/u004V/jW..1JuoiFdatIuYeZtMVlJRrpuNqr8s2zI8asWh1jF92e'
        },
        success: function(response) {
            $("#btn-Search").click(function() {
                console.log(response);
                updateDataOfTable(response.record);
                formatNumberInput();
            });
            configDateDefault();
        },
        error: function(xhr, status, error) {
            console.error('Error fetching data:', error);
        }
    });
    
});


function updateDataOfTable(datas) {
    $("#tbodyDanhSachBenhNhan").empty();
    $.each(datas, (i, data) => $("#tbodyDanhSachBenhNhan").append(getRowTable(data, i)));
};



function getRowTable(data, i) {
    
    return `<tr>
    <td class="text-center MaKhoa">${i+1}</td>
    <td class="text-center MaKhoa">${data.makhoa}</td>
    <td class="text-start TenKhoa">${data.tenkhoa}</td>
    <td class="text-center CapCuu">
        <input class="form-check-input" type="checkbox" ${data.capcuu == true ? "checked" :  ""} disabled></input>
    </td>
    <td class="text-end GiaKham formatted-number">${data.giakham}</td>
    <td class="text-center Ngaytao input-date-mask">${formatDay(data.ngaytao)}</td>
     </tr>`
}


    








