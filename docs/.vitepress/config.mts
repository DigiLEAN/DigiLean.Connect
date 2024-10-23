import { defineConfig } from 'vitepress'
import { sidebar } from "../services/openApi"

// https://vitepress.dev/reference/site-config
export default defineConfig({
  head: [
    ["link", { rel: "icon", type:"image/svg+xml", href: "/logo.svg" }],
    ["link", { rel: "icon", type:"image/x-icon", href: "/favicon.ico" }]
  ],
  lang: "en-US",
  title: "DigiLEAN Connect",
  description: "API Documentation",
  themeConfig: {
    logo: "logo.svg",
    // https://vitepress.dev/reference/default-theme-config
    nav: [
      { text: 'Docs', link: '/docs' },
      { text: 'Examples', link: '/examples' }
    ],

    sidebar: {
      "/docs/": [
        {
          text: 'Overview',
          items: [
            { text: 'Get started', link: '/docs/' },
            { text: 'Authentication', link: '/docs/authentication' },
            { text: 'Scopes', link: '/docs/scopes' },
          ]
        },
        {
          text: 'Querying',
          items: [
            { text: 'Filter resource', link: '/docs/filtering' }
          ]
        },
        /// OpenAPI docs
        ...sidebar.generateSidebarGroups(),
        {
          text: 'Microsoft',
          items: [
            { text: 'Entra Id Apps', link: '/docs/microsoft-entra' }
          ]
        }
      ],
      "/examples/": [
        {
          text: 'Examples',
          items: [
            { text: 'Datasources', link: '/examples/datasource-get' },
            { text: 'Datavalue Add', link: '/examples/datasource-value-post' },
          ]
        }
      ]
    },
    socialLinks: [
      { icon: 'github', link: 'https://github.com/DigiLEAN/DigiLEAN.Connect' },
      { icon: 'linkedin', link: 'https://www.linkedin.com/company/kaizen-solutions-as' }
    ]
  },
  cleanUrls: true,
  vue: {
    template: {
        compilerOptions: {
            isCustomElement: (tag) => {
                return tag.includes("digilean-");
            }
        }
    }
  },
})
