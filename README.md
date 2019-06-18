# UIElements-Sass
Create Unity UIElements stylesheets (uss files) using [Sass](https://sass-lang.com/).
Works great alongside [UIElements-Slim](https://github.com/eidetic-av/UIElements-Slim).

## Why?
Nested rules, mixins, loops and other directives. You can learn more about Sass features [here](https://sass-lang.com/documentation).

By using Sass to write UIElements stylesheets instead of plain uss, you can write this:
```sass
YourElement
    Slider
        margin-top: -10px
        height: 120px
        
        #unity-tracker
            background-color: #898989
            margin-left: 2px
            width: 4px
            
        #unity-dragger
            width: 35px
            height: 25px
```
instead of this:
```css
YourElement Slider {
  margin-top: -10px;
  height: 120px;
}
YourElement Slider #unity-tracker {
  background-color: #898989;
  margin-left: 2px;
  width: 4px;
}
YourElement Slider #unity-dragger {
  width: 35px;
  height: 25px;
}
```

It has some more advanced features too...

Here's some iteration over an array of image sizes:
```sass
$sizes: 40px, 50px, 80px

@each $size in $sizes
  .icon-#{$size}
    height: $size
    width: $size
    
    Label
      font-size: $size / 2
```
It compiles to this:
```css
.icon-40px {
  height: 40px;
  width: 40px;
}
.icon-40px Label {
  font-size: 20px;
}

.icon-50px {
  height: 50px;
  width: 50px;
}
.icon-50px Label {
  font-size: 25px;
}

.icon-80px {
  height: 80px;
  width: 80px;
}
.icon-80px Label {
  font-size: 40px;
}
```

## Usage
This only works on x64 Windows at the moment.

It relies on [SharpScss](https://github.com/xoofx/SharpScss) and [libsass](https://github.com/sass/libsass), and I've only included dlls built for Windows x64, but it should work fine if you build these dlls for your own platform.

I'll probably include the libraries in for different platforms soon.

A big thankyou to those two projects!

## To-do
* Error checking if there is something wrong with the input sass file.
