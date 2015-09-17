(function () {
    'use strict';

    angular.module('kpmg.Admin').controller("transactionData", function ($scope, apiCall, dataConverter, dialogs, messageBuilder, tableFilter) {

        $scope.table = {
            Columns: ["Account", "Description", "CurrencyCode", "Amount"],
            Account: "",
            Description: "",
            CurrencyCode: "",
            Amount: 0
        };

        $scope.init = function () {
            apiCall([
                { url: "/ModelBuilder/TransactionDataSearchFilter" }
            ]).then(function (data) {
                $scope.searchFilter = data[0];
                $scope.sortOrderInit();
                $scope.querySearch();
            });
        };

        $scope.applySearchFilter = function () {
            $scope.querySearch();
        };

        $scope.querySearch = function () {
            console.log($scope.searchFilter);
            apiCall([
                { postMethod: "POST", url: "http://localhost:52759/api/TransactionData/Search", data: { searchFilter: $scope.searchFilter } }
            ]).then(function (data) {
                $scope.model = data[0];
                //$scope.friendlyDisplay();
            });
        };

        //$scope.friendlyDisplay = function () {
        //    var i = $scope.model.Clients.length;
        //    while (i-- > 0) {
        //        $scope.model.Clients[i].CreatedDate = dataConverter.date($scope.model.Clients[i].CreatedDate);
        //        $scope.model.Clients[i].UpdatedDate = dataConverter.date($scope.model.Clients[i].UpdatedDate);
        //    }
        //};

        //$scope.deleteTransactionData = function(client) {
        //    var dlg = dialogs.confirm("Confirm to Delete", "Are you sure you want to delete '" + client.Name + "'?");
        //    dlg.result.then(function (btn) {
        //        apiCall([
        //            { postMethod: "POST", url: "/Clients/DeleteClient", data: { clientId: client.Id } }
        //        ]).then(function (data) {
        //            dialogs.notify("Infomation", data[0]);
        //            $scope.itemPerPageSetPage();
        //        }, function (error) {
        //            dialogs.error("Error", messageBuilder.modalErrorSummary(error));
        //        });
        //    });
        //}

        // Table Paging and Sorting        
        $scope.itemPerPageSetPage = function () {
            tableFilter.itemPerPageSetPage($scope.searchFilter.Filter.Paging, $scope.model.Paging.ItemsPerPage);
            $scope.querySearch();
        };

        $scope.paginationSetPage = function () {
            tableFilter.paginationSetPage($scope.searchFilter.Filter.Paging, $scope.model.Paging.CurrentPage);
            $scope.querySearch();
        };

        $scope.sortOrderInit = function () {
            tableFilter.sortOrderResetPage($scope.table);
            tableFilter.sortOrderInit($scope.table, $scope.searchFilter.Filter.Sorting);
        };

        $scope.sortOrderSetPage = function (column) {
            tableFilter.sortOrderResetPage($scope.table);
            if (tableFilter.sortOrder($scope.table, $scope.searchFilter.Filter.Sorting, column)) {
                $scope.querySearch();
            }
        }
    });
})();