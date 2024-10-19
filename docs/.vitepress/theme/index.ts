// https://vitepress.dev/guide/custom-theme
import { h } from "vue"
import type { Theme } from "vitepress"
import DefaultTheme from "vitepress/theme"
import "./style.css"

import { theme } from "vitepress-openapi"
import "vitepress-openapi/dist/style.css"
import "./colors.css"
import "./theme.css"
import { getOpenApi } from "../../services/openApi"
// import "../../components/digiLeanLogo"
// import "../../components/digiLeanButton"
//import "../../components"

export default {
  extends: DefaultTheme,
  Layout: () => {
    return h(DefaultTheme.Layout, null, {
      // https://vitepress.dev/guide/extending-default-theme#layout-slots
    })
  },
  enhanceApp({ app, router, siteData }) {
    const opa = getOpenApi()
    theme.enhanceApp({ app })
  },
  
} satisfies Theme
