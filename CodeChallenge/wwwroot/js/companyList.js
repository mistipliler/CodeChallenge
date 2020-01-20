var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/company",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "25%" },
            { "data": "exchange", "width": "15%" },
            { "data": "ticker", "width": "10%" },
            { "data": "isin", "width": "15%" },
            { "data": "website", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/CompanyList/Upsert?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                                    Edit
                                </a>
                            </div>`;
                }, "width": "40%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}