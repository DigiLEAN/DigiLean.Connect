import { usePaths } from "vitepress-openapi"

import spec from "../../../openApi/OpenApi3.0.v2.json" with { type: "json" }

export default {
    paths() {
        return usePaths({ spec })
            .getPathsByVerbs()
            .map(({ operationId, summary }) => {
                return {
                    params: {
                        operationId,
                        pageTitle: `${summary} - vitepress-openapi`,
                    },
                }
            })
    }
}