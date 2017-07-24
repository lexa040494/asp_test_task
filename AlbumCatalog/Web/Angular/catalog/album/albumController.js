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
                },
                {
                    field: 'EditDeleteAlbum',
                    displayName: '',
                    width: '5%',
                    headerTooltip: true,
                    enableFiltering: false,
                    cellTemplate: 'Angular/catalog/album/template/editDeleteAlbum.html',
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

        $scope.openModalAddEditAlbum = function (album) {
            $uibModal.open({
                templateUrl: function () { return 'Angular/catalog/album/modal/newAlbum.html?' + new Date() },
                size: 'md',
                scope: $scope,
                controller: [
                    '$rootScope', '$scope', '$uibModalInstance', function ($rootScope, $scope, $uibModalInstance) {
                        $scope.currentAlbum = {};

                        if (album == null) {
                            $scope.modalTitle = 'Создание нового альбома';
                            $scope.currentAlbum = {
                                Name: '',
                                Year: '',
                                Tracks: [
                                    {
                                        Name: '',
                                        Artist: '',
                                        Duration: ''
                                    }
                                ]
                            };
                        } else {
                            $scope.modalTitle = 'Редактирование альбома';
                            $scope.currentAlbum = angular.copy(album);
                            $scope.currentAlbum.Tracks.forEach(function(item) {
                                item.Duration = new Date(new Date() + item.Duration);
                            });
                        }
                        

                        $scope.newTrack = function() {
                            $scope.currentAlbum.Tracks.push({
                                name: '',
                                artist: '',
                                duration: ''
                            });
                        };

                        $scope.removeTrack = function(itemToAdd) {
                            var index = $scope.currentAlbum.Tracks.indexOf(itemToAdd);

                            $scope.currentAlbum.Tracks.splice(index, 1);
                        };

                        $scope.canselModal = function () {
                            $uibModalInstance.dismiss({ $value: 'cancel' });
                        };

                        $scope.saveAlbum = function () {
                            $uibModalInstance.close($scope.currentAlbum);
                        };
                    }
                ]
            }).result.then(function (result) {
                if (album == null) {
                    albumService.AddAlbum(result).then(function() {
                        $scope.gridAlbum.data.push(result);
                        $rootScope.toaster('success', 'Новый альбом был успешно добавлен.', 4000);
                    }, function(errorObject) {
                        $rootScope.toaster('error', errorObject.ExceptionMessage, 4000);
                    }).finally(function() {
                        $scope.loadingInfo = false;
                        $scope.currentAlbum = {};
                    });
                } else {
                    albumService.EditAlbum(result).then(function () {
                        var index = $scope.gridAlbum.data.findIndex(function (element, index, array) {
                            if (element.Id == result.Id)
                                return true;
                            return false;
                        });
                        $scope.gridAlbum.data[index] = result;
                        $rootScope.toaster('success', 'Альбом был успешно обновлен.', 4000);
                    }, function (errorObject) {
                        $rootScope.toaster('error', errorObject.ExceptionMessage, 4000);
                    }).finally(function () {
                        $scope.loadingInfo = false;
                        $scope.currentAlbum = {};
                    });
                }
            });
        };

    };

    // register your controller into a dependent module 
    angular
        .module("Web.Controllers")
        .controller("albumController", ["$scope", "$rootScope", "albumService", "uiGridConstants", "$uibModal", albumController]);

})();