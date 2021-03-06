var gulp = require('gulp'),
    pug = require('gulp-pug'),
    useref = require('gulp-useref'),
    serve = require('gulp-serve');


gulp.task('pug', () => {
    return gulp.src(['**/*.pug','!node_modules/**/*.pug'])
        .pipe(pug({
            doctype : 'html',
            pretty: true
        }))
        .pipe(gulp.dest((file) => {
            return file.base;
        }))
});

gulp.task('build', () => {
    return gulp.src('**/*.html','!node_modules/**/*.html')
            .pipe(useref())
            .pipe(gulp.dest('dist'));
});