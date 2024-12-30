import { defineConfig } from 'vitepress'
import { sidebar } from "../services/openApi"

// https://vitepress.dev/reference/site-config
export default defineConfig({
  head: [
    ["link", { rel: "icon", type:"image/svg+xml", href: "/images/logo.svg" }],
    ["link", { rel: "icon", type:"image/x-icon", href: "/favicon.ico" }],
    ["script", { src: "/3d/digilean3dlogo.js" }]
  ],
  lang: "en-US",
  title: "DigiLEAN Connect",
  description: "API Documentation",
  themeConfig: {
    logo: "/images/logo.svg",
    // https://vitepress.dev/reference/default-theme-config
    nav: [
      { text: 'Docs', link: '/docs' },
      { text: 'Examples', link: '/examples' },
      { text: 'Enterprise', link: '/enterprise' }
    ],
    search: {
      provider: "local"
    },
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
        ...sidebar.generateSidebarGroups()
      ],
      "/examples/": [
        {
          text: 'Examples',
          items: [
            { text: 'Datasources', link: '/examples/datasource-get' },
            { text: 'Datavalue Add', link: '/examples/datasource-value-post' },
            { text: "Datavalue Update", link: "/examples/datasource-value-update"}
          ]
        }
      ],
      "/enterprise/": [
        {
          text: 'Microsoft',
          items: [
            { text: 'Enterprise Applications', link: '/enterprise/' },
            { text: 'Enable Sharepoint site access', link: "/enterprise/connect-sharepoint-sites"}
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
  vite: {
    build: {
      rollupOptions: {
        external: ["/3d/digilean3dlogo.js"]
      }
    }
  }
})
