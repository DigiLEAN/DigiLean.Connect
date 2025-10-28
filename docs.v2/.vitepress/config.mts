import { defineConfig } from 'vitepress'

import { useSidebar } from 'vitepress-openapi'
import spec from "../api.v2/openApi.json" with { type: 'json' }

const sidebar = useSidebar({
    spec,
    // Optionally, you can specify a link prefix for all generated sidebar items. Default is `/operations/`.
    linkPrefix: '/api.v2/operations/',
})


// https://vitepress.dev/reference/site-config
export default defineConfig({
  title: "DigiLEAN Connect",
  description: "DigiLEAN Connect Docs",
  themeConfig: {
    // https://vitepress.dev/reference/default-theme-config
    nav: [
      { text: 'Home', link: '/' },
      { text: 'Examples', link: '/markdown-examples' }
    ],

    sidebar: [
        ...sidebar.generateSidebarGroups({
            // Optionally, you can generate sidebar items with another link prefix. Default is `/operations/`.
            linkPrefix: '/api.v2/operations/',

            // Optionally, you can specify a list of tags to generate sidebar items. Default is all tags.
            //tags: [],
        }),
    ],
    // sidebar: [
    //   {
    //     text: 'Examples',
    //     items: [
    //       { text: 'Markdown Examples', link: '/markdown-examples' },
    //       { text: 'Runtime API Examples', link: '/api-examples' }
    //     ]
    //   }
    // ],

    socialLinks: [
      { icon: 'github', link: 'https://github.com/vuejs/vitepress' }
    ]
  }
})
