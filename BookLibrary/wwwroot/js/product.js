$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    $('#tblData').DataTable({
        "ajax": {
            url: '/admin/product/getall',
        },
        "columns": [
            { data: 'Title', "width": "25%" },
            { data: 'ISBN', "width": "25%" },
            { data: 'ListPrice', "width": "25%" },
            { data: 'Author', "width": "25%" },
            { data: 'Category.Name', "width": "25%" }
        ],
        "paging": true,
        "pageLength": 10,
        "searching": true,
        "ordering": true,
        "info": true
    });
}