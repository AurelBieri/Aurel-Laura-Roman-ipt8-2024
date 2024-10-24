const { defineConfig } = require('@vue/cli-service');
const webpack = require('webpack'); // Webpack importieren

module.exports = defineConfig({
  transpileDependencies: true,

  // Erweiterung der Webpack-Konfiguration, um die Feature-Flags hinzuzufügen
  configureWebpack: {
    plugins: [
      new webpack.DefinePlugin({
        __VUE_OPTIONS_API__: true, // Standard-Flag
        __VUE_PROD_DEVTOOLS__: false, // Deaktiviere DevTools in Produktion
        __VUE_PROD_HYDRATION_MISMATCH_DETAILS__: false, // Deaktiviere die Hydration-Mismatch-Details
      }),
    ],
  },
});
