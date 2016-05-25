/// <reference path="../../angular.js" />
/// <reference path="../App.js" />

PlannerApp.directive('ngEnter', function () {
	return {
		restrict: 'A',
		link: function (scope, element, attrs) {
			element.bind("keydown", function (event) {

				if (event.which === 13) {
					scope.$apply(function () {
						scope.$eval(attrs.ngEnter, { $event: event });
					});

					event.preventDefault();
				}
			});
		}
	}
});