import type { Theme } from "vitepress"
import DefaultTheme from "vitepress/theme"
import "./style.css"

import { theme } from "vitepress-openapi/client"
import "vitepress-openapi/dist/style.css"
import "./colors.css"
import "./theme.css"
import openAPI from "../../services/openApi"

export default {
  extends: DefaultTheme,
  enhanceApp({ app }) {
    const _ = openAPI
    theme.enhanceApp({ app })
  },
  
} satisfies Theme
