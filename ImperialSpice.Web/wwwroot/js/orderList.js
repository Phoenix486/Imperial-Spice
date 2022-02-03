﻿var dataTable;
$(document).ready(function () {
    var url = window.location.search
    if (url.includes("cancelled")) {
        loadList("cancelled");
    }
    else {
        if (url.includes("completed")) {
            loadList("completed");
        }
        else {
            if (url.includes("ready")) {
                loadList("ready");
            }
            else {
                loadList("inprocess");
            }
        }
    }
});

function loadList(param){
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/Order?status=" + param,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "pickupName", "width": "15%" },
            { "data": "applicationUser.email", "width": "20%" },
            { "data": "orderTotal", "width": "10%" },
            { "data": "pickUpTime", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="w-55">
                                <a href="/Admin/Order/OrderDetails?id=${data}"  class="btn btn-success mx-2">
                                    <i class="bi bi-pencil-square"></i>
                                </a>
                            </div>`
                },

                "width": "15%"
            }
        ],
        "width": "100%"
    });
}