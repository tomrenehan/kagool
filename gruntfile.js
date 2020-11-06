/// <binding ProjectOpened='default' />
module.exports = function (grunt) {
    const sass = require('node-sass');

    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),

        // Sass
        sass: {
            options: {
                sourceMap: true,
                outputStyle: 'compressed',
                implementation: sass
            },
            dist: {
                files: [
                    {
                        expand: true, // Recursive
                        cwd: "Styles", // Startup dir
                        src: ["**/*.scss"], // File source
                        dest: "wwwroot/css", // Dest
                        ext: ".css" // Extension
                    }
                ]
            }
        },
        watch: {
            scripts: {
                files: ['**/*.scss'],
                tasks: ['sass:dist']
            }
        }
    });

    // Load the plugin
    grunt.loadNpmTasks('grunt-sass');
    grunt.loadNpmTasks('grunt-contrib-watch');

    // Default task(s).
    grunt.registerTask('default', ['watch']);
};