import React from 'react'

import ReactMarkdown from 'react-markdown'
import remarkGfm from 'remark-gfm'

const markdown = `
### GiBookについて
GiBookとは本を誰かにGiveすることを言います。

GiBook会の参加者はアプリ上で誰かにGiveしたい書籍を登録することでGiBook会に参加することができます。

GiBook会に参加すると誰かから本を受け取ることができます。
誰から本を受け取れるかはアプリ上でマッチングされます。

|  | 日程 | 概要 |
| - | - | - |
| 1 | 2022年2月○日 | IT系技術書でGiBook会を開催予定 |
`

const About = () => {
  return (
    <div>
      <ReactMarkdown children={markdown} remarkPlugins={[remarkGfm]} />
    </div>
  )
}

export default About
