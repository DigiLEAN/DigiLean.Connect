import { useSidebar } from "vitepress-openapi"
import { useOpenapi, generateCodeSample, OARequest } from "vitepress-openapi/client"

import spec from "../openApi/OpenApi3.0.v2.json" with { type: "json" }

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
                    return new Promise(r => r(generateBruRequest(request)))
                }
                return generateCodeSample(lang, request)
            }
        }
    }
});

function generateBruRequest(request: OARequest) {
    const { url, method, headers, body, query } = request;
  
    const methodLower = method.toLowerCase();
  
    const queryString = query && Object.keys(query).length
      ? `${url}?${new URLSearchParams(query).toString()}`
      : url;
  
    const headersSection = headers && Object.keys(headers).length
      ? `headers {\n${Object.entries(headers)
          .map(([key, value]) => `  ${key}: ${value}`)
          .join('\n')}\n}`
      : '';
  
    const bodySection = body
      ? `body {\n  ${JSON.stringify(body, null, 2).replace(/\n/g, '\n  ')}\n}`
      : '';
  
    const bruRequest = `${methodLower} {
        url: ${queryString}
    }

        ${headersSection}

        ${bodySection}
    `;

    return bruRequest
        .trim()
        .replace(/\n{2,}/g, '\n\n') // Remove extra newlines
}

export const sidebar = useSidebar({ 
  spec,
  // Optionally, you can specify a link prefix for all generated sidebar items.
  linkPrefix: '/docs/v2/operations/',
})