/// <reference path="topMenuDirective/topMenu.js" />
(function () {
    "use strict";

    // controller class definintion
    var albumController = function ($scope, $rootScope, albumService, uiGridConstants, $uibModal) {
        $scope.loadingInfo = true;

        $scope.gridAlbum = {
            enableColumnResizing: true,
            showGridFooter: false,
            enableHorizontalScrollbar: 0,
            enableVerticalScrollbar: 1,
            enableColumnMenus: false,
            showColumnFooter: true,
            enableFiltering: true,
            selectionRowHeaderWidth: 25,
            enableRowSelection: true,
            enableSelectAll: true,
            multiSelect: true,
            rowHeight: 25,
            headerRowHeight: 20,
            expandableRowTemplate: "Angular/catalog/album/template/expandableGrid.html",
            expandableRowHeight: 150,
            columnDefs: [
                {
                    field: 'Name',
                    width: '60%',
                    displayName: 'Название альбома',
                    headerTooltip: true,
                    enableFiltering: false
                },
                {
                    field: 'Year',
                    displayName: 'Год выпуска',
                    headerTooltip: true,
                    enableFiltering: false
                }
            ],
            onRegisterApi: function (gridApi) {
                gridApi.expandable.on.rowExpandedStateChanged($scope, function (row) {
                    if (row.isExpanded) {
                        row.entity.subGridOptions = {
                            columnDefs: [
                            {
                                field: 'Name',
                                width: '40%',
                                displayName: 'Название трека',
                                headerTooltip: true,
                                enableFiltering: false
                            },
                            {
                                field: 'Artist',
                                displayName: 'Исполнитель',
                                headerTooltip: true,
                                enableFiltering: false
                            },
                            {
                                field: 'Duration',
                                width: '20%',
                                displayName: 'Продолжительность',
                                headerTooltip: true,
                                enableFiltering: false
                            }
                            ]
                        };

                        row.entity.subGridOptions.data = row.entity.Tracks;

                    }
                });
            }
        };

        $scope.GetAllAlbums = function () {
            albumService.GetAllAlbums().then(function (response) {
                $scope.gridAlbum.data = response;
            }, function (errorObject) {
                $rootScope.toaster('error', errorObject.ExceptionMessage, 4000);
            }).finally(function () {
                $scope.loadingInfo = false;
            });
        };

        $scope.GetAllAlbums();

    };

    // register your controller into a dependent module 
    angular
        .module("Web.Controllers")
        .controller("albumController", ["$scope", "$rootScope", "albumService", "uiGridConstants", "$uibModal", albumController]);

})();