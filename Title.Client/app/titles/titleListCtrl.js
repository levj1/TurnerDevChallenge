(function () {
    "use strict";
    angular
        .module("titleApp")
        .controller("TitleListCtrl",
                    ["titleResource",
                     TitleListCtrl]);

    function TitleListCtrl(titleResource) {
        var vm = this;

        vm.searchTitle = "All";

        titleResource.query({search: vm.searchTitle}, function (data) {
            vm.titles = data;
        });
       
    }
}());