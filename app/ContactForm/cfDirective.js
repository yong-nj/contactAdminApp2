
contactAdminApp2.directive('contactForm',
    function () {
        
        return {
            restrict: 'E',
            templateUrl: 'app/ContactForm/cfContact.html'
        }

    });


//angular.module('contactAdminApp2')
//    .directive('uibDatepickerPopup', function () {
//        return {
//            restrict: 'EAC',
//            require: 'ngModel',
//            link: function (scope, elem, attrs, ngModel) {
//                ngModel.$parsers.push(function toModel(date) {
//                    //  return date.getFullYear() + '-' + (date.getMonth() + 1) + '-' + date.getDate();
//                    return '1988-01-01';
//                });
//            }
//        }
//    });