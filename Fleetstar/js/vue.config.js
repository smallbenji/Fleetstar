module.exports = {
    outputDir: "../wwwroot/js/dist", // Output everything into the `dist` folder
    assetsDir: "", // Prevent nested `assets` folder
    publicPath: "/js/dist/", // Use relative paths for assets
    filenameHashing: false, // Disable hash in filenames
    runtimeCompiler: true, // Enable runtime compilation
    css: {
        extract: false,
        loaderOptions: {
            sass: {
                implementation: require('sass'),
            }
        }
    },
    configureWebpack: {
        resolve: {
            extensions: ['.vue', '.js', '.json'],
        },
        output: {
            filename: '[name].js', // Keep the main app filename dynamic
            chunkFilename: '[name].js', // Ensure chunk filenames are unique
        },
    },
    chainWebpack: config => {
        config.optimization.splitChunks(false); // Disable chunk splitting
    },
};