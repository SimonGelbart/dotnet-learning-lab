#!/usr/bin/env bash
set -euo pipefail
ROOT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
ROOT_URI="${ROOT_DIR// /%20}"

find "$ROOT_DIR/learning-paths" -path '*/presentation/presentation.html' -type f | while read -r HTML; do
  OUT="$(dirname "$HTML")/presentation.local.html"
  python3 - "$HTML" "$OUT" "$ROOT_URI" <<'LOCAL_LINKS_PY'
import sys, pathlib
src, dst, root = sys.argv[1:]
text = pathlib.Path(src).read_text(encoding='utf-8')
text = text.replace("window.localRootUri='';", f"window.localRootUri={root!r};")
pathlib.Path(dst).write_text(text, encoding='utf-8')
print(f"Generated {dst}")
LOCAL_LINKS_PY
done
