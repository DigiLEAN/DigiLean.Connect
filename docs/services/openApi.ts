import { useSidebar } from "vitepress-openapi"
import { useOpenapi, generateCodeSample } from "vitepress-openapi/client"

import spec from "../openApi/OpenApi3.0.v1.json" with { type: "json" }

export default useOpenapi({
    spec,
    config: {
        codeSamples: {
            // List of languages to show in Code Samples section.
            langs: [
                'bruno',
            ],
            // List of available languages to select from.
            availableLanguages: [
                {
                    lang: 'bruno',
                    label: 'Bruno',
                    highlighter: 'plaintext',
                },
            ],
            defaultLang: 'bruno',
            generator: (lang: string, request) => {
                if (lang === 'bruno') {
                    return generateBruRequest(request)
                }
                return generateCodeSample(lang, request)
            }
        }
    }
});

export const sidebar = useSidebar({ 
  spec,
  // Optionally, you can specify a link prefix for all generated sidebar items.
  linkPrefix: '/docs/operations/',
})