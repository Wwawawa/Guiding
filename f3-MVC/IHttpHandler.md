[IHttpHandler Introduction](http://blog.csdn.net/liu_111111/article/details/8439835)
* [ashx introduction](http://www.cnblogs.com/lgx5/p/5629028.html)
* angular call ashx can by directive which set the ashx path into 'src' property of element.
```js
  test.directive('test', [function () {
      return {
          restrict: 'A',
          replace: false,
          link: function (scope, elem, attr) {
              var src = '/test.ashx?param1=test';
              elem.attr('src', src);
          }
      }
  }]);

```
