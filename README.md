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
}
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
UIElements-Sass assumes you have a working sass command-line installation.

If you're on MacOs, you can use [Homebrew](https://brew.sh/): `brew install sass/sass/sass` to download the latest dart-sass.

And if you're on Windows (assuming you have [Chocolately](https://chocolatey.org/)) , you can go `choco install sass`.

For other OSs go [here](https://sass-lang.com/install).

Once you've done that, clone this repo, add it as a submodule, or download the zip and extract it into your project.

The compiler will be run every time a ".sass" file is created or altered inside your project, and the resulting ".uss" file will be placed alongside it in the same folder.

## To-do
* A terminal window appears on every compile, so it would be nice to hide this.
* I know Unity runs it's own nodejs server for some tasks... it would be nice to be able to utilise this somehow so that we can use the node based sass instead of the command line wrapper.
